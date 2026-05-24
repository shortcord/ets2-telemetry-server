using System;
using System.Runtime.CompilerServices;

namespace Funbit.Ets.Telemetry.Data
{
    public sealed class Ets2Job
    {
        private readonly StrongBox<Ets2TelemetryStructure> _rawData;

        public Ets2Job(StrongBox<Ets2TelemetryStructure> rawData)
        {
            _rawData = rawData;
        }

        public int Income => _rawData.Value.jobIncome;
        public DateTime DeadlineTime => _rawData.Value.jobDeadline.MinutesToDate();
        public DateTime RemainingTime =>
            _rawData.Value.jobDeadline > 0
                ? (_rawData.Value.jobDeadline - _rawData.Value.timeAbsolute).MinutesToDate()
                : 0.MinutesToDate();

        public string SourceCity => _rawData.Value.jobCitySource.BytesToString();
        public string SourceCompany => _rawData.Value.jobCompanySource.BytesToString();
        public string DestinationCity => _rawData.Value.jobCityDestination.BytesToString();
        public string DestinationCompany => _rawData.Value.jobCompanyDestination.BytesToString();
    }
}
