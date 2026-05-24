﻿﻿using System;

namespace Funbit.Ets.Telemetry.Data
{
    public sealed class ScsTelemetryClient : IDisposable
    {
        private readonly SharedProcessMemory<Ets2TelemetryStructure> _sharedMemory;
        private readonly object _lockObject;
        
        public ScsTelemetryClient(string? sharedMemoryFilePath)
        {
            if (string.IsNullOrWhiteSpace(sharedMemoryFilePath))
                throw new ArgumentException("Shared memory file path must be provided.", nameof(sharedMemoryFilePath));

            _sharedMemory = new SharedProcessMemory<Ets2TelemetryStructure>(sharedMemoryFilePath);
            _lockObject = new object();
        }
        
        public bool IsConnected
        {
            get
            {
                lock (_lockObject)
                    return _sharedMemory?.IsConnected ?? false;
            }
        }

        public Ets2TelemetryData? Read()
        {
            lock (_lockObject)
            {
                if (!_sharedMemory.IsConnected)
                    return null;

                _sharedMemory.Data = default;
                _sharedMemory.Read();

                return new Ets2TelemetryData(_sharedMemory.Data);
            }
        }
        
        public void Dispose()
        {
            lock (_lockObject)
                _sharedMemory?.Dispose();
        }
    }
}