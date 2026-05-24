using System;
using System.Runtime.CompilerServices;

namespace Funbit.Ets.Telemetry.Data
{
    public sealed class Ets2Navigation
    {
        private readonly StrongBox<Ets2TelemetryStructure> _rawData;

        public Ets2Navigation(StrongBox<Ets2TelemetryStructure> rawData)
        {
            _rawData = rawData;
        }

        public DateTime EstimatedTime => ((int)_rawData.Value.navigationTime).SecondsToDate();
        public int EstimatedDistance => (int)_rawData.Value.navigationDistance;
        public int SpeedLimit => _rawData.Value.navigationSpeedLimit > 0
            ? (int)Math.Round(_rawData.Value.navigationSpeedLimit * 3.6f)
            : 0;
    }
}
