using System;
using System.Diagnostics;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Runtime.InteropServices;

namespace Funbit.Ets.Telemetry.Data
{
    /// <summary>
    /// Reads a fixed-size structure from a named memory-mapped file.
    /// </summary>
    /// <typeparam name="T">The structure type stored in shared memory.</typeparam>
    class SharedProcessMemory<T> : IDisposable where T : struct
    {
        readonly string _mapName;
        readonly int _dataSize;

        FileStream? _fileStream;
        MemoryMappedFile? _memoryMappedFile;
        MemoryMappedViewAccessor? _memoryMappedAccessor;
        bool _disposed;

        /// <summary>
        /// Gets or sets the last successfully read value.
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Gets a value indicating whether the shared memory view has been opened.
        /// </summary>
        public bool IsConnected
        {
            get
            {
                InitializeViewAccessor();
                return _memoryMappedAccessor != null;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SharedProcessMemory{T}"/> class.
        /// </summary>
        /// <param name="mapName">The name of the memory-mapped file to open.</param>
        public SharedProcessMemory(string mapName)
        {
            if (string.IsNullOrWhiteSpace(mapName))
                throw new ArgumentException("Map name must be provided.", nameof(mapName));

            _mapName = mapName;
            _dataSize = Marshal.SizeOf(typeof(T));
            Data = default(T);
        }

        /// <summary>
        /// Opens the shared memory view on demand.
        /// </summary>
        void InitializeViewAccessor()
        {
            if (_disposed || _memoryMappedAccessor != null)
                return;

            try
            {
                if (!OperatingSystem.IsWindows() || Path.IsPathRooted(_mapName))
                {
                    _fileStream = new FileStream(
                        _mapName,
                        FileMode.Open,
                        FileAccess.Read,
                        FileShare.ReadWrite);

                    _memoryMappedFile = MemoryMappedFile.CreateFromFile(
                        _fileStream,
                        mapName: null,
                        capacity: 0,
                        access: MemoryMappedFileAccess.Read,
                        inheritability: HandleInheritability.None,
                        leaveOpen: true);
                }
                else
                {
                    _memoryMappedFile = MemoryMappedFile.OpenExisting(_mapName, MemoryMappedFileRights.Read);
                }

                _memoryMappedAccessor = _memoryMappedFile.CreateViewAccessor(0, _dataSize, MemoryMappedFileAccess.Read);
            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Reads the current contents of the shared memory block into <see cref="Data"/>.
        /// </summary>
        public void Read()
        {
            InitializeViewAccessor();

            if (_memoryMappedAccessor == null)
                return;

            byte[] rawData = new byte[_dataSize];
            _memoryMappedAccessor.ReadArray(0, rawData, 0, rawData.Length);

            IntPtr reservedMemPtr = IntPtr.Zero;
            try
            {
                reservedMemPtr = Marshal.AllocHGlobal(rawData.Length);
                Marshal.Copy(rawData, 0, reservedMemPtr, rawData.Length);
                Data = Marshal.PtrToStructure<T>(reservedMemPtr);
            }
            finally
            {
                if (reservedMemPtr != IntPtr.Zero)
                    Marshal.FreeHGlobal(reservedMemPtr);
            }
        }

        /// <summary>
        /// Releases the memory-mapped file and its accessor.
        /// </summary>
        public void Dispose()
        {
            if (_disposed)
                return;

            _disposed = true;

            if (_memoryMappedAccessor != null)
                _memoryMappedAccessor.Dispose();

            if (_memoryMappedFile != null)
                _memoryMappedFile.Dispose();

            if (_fileStream != null)
                _fileStream.Dispose();
        }
    }
}
