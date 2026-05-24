using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace Funbit.Ets.Telemetry.Data
{
    public sealed class Ets2Trailer
    {
        readonly StrongBox<Ets2TelemetryStructure> _rawData;

        public Ets2Trailer(StrongBox<Ets2TelemetryStructure> rawData)
        {
            _rawData = rawData;
        }

        public bool Attached => _rawData.Value.trailer_attached != 0;
        public string Id => _rawData.Value.trailerId.BytesToString();
        public string Name => _rawData.Value.trailerName.BytesToString();

        /// <summary>
        /// Trailer mass in kilograms.
        /// </summary>
        public float Mass => _rawData.Value.trailerMass;

        public float Wear => _rawData.Value.wearTrailer;

        public Ets2Placement Placement => new Ets2Placement(
            _rawData.Value.trailerCoordinateX,
            _rawData.Value.trailerCoordinateY,
            _rawData.Value.trailerCoordinateZ,
            _rawData.Value.trailerRotationX,
            _rawData.Value.trailerRotationY,
            _rawData.Value.trailerRotationZ);
    }
}
