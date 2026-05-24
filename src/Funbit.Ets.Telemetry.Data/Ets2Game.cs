using System;
using System.Runtime.CompilerServices;

namespace Funbit.Ets.Telemetry.Data
{
    public sealed class Ets2Game  
    {
        readonly StrongBox<Ets2TelemetryStructure> _rawData;

        public Ets2Game(StrongBox<Ets2TelemetryStructure> rawData)
        {
            _rawData = rawData;
        }

        public bool Connected => _rawData.Value.ets2_telemetry_plugin_revision != 0 &&
                                 _rawData.Value.timeAbsolute != 0;

        public bool Paused => _rawData.Value.paused != 0;
        public DateTime Time => _rawData.Value.timeAbsolute.MinutesToDate();
        public float TimeScale => _rawData.Value.localScale;
        public DateTime NextRestStopTime => _rawData.Value.nextRestStop.MinutesToDate();
        public string Version => $"{_rawData.Value.ets2_version_major}.{_rawData.Value.ets2_version_minor}";
        public string TelemetryPluginVersion => _rawData.Value.ets2_telemetry_plugin_revision.ToString();
    }
}
