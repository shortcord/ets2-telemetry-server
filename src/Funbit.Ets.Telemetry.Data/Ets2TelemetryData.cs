using System.IO;
using System.Runtime.CompilerServices;

namespace Funbit.Ets.Telemetry.Data
{
    public class Ets2TelemetryData
    {
        public Ets2Game Game { get; init; }
        public Ets2Truck Truck { get; init; }
        public Ets2Trailer Trailer { get; init; }
        public Ets2Job Job { get; init; }
        public Ets2Navigation Navigation { get; init; }

        public Ets2TelemetryData(Ets2TelemetryStructure rawData)
        {
            var scopedData = new StrongBox<Ets2TelemetryStructure>(rawData);

            Game = new Ets2Game(scopedData);
            Truck = new Ets2Truck(scopedData);
            Trailer = new Ets2Trailer(scopedData);
            Job = new Ets2Job(scopedData);
            Navigation = new Ets2Navigation(scopedData);
        }
    }
}
