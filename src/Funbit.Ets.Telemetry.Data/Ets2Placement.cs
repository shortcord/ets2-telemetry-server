namespace Funbit.Ets.Telemetry.Data
{
    public sealed class Ets2Placement
    {
        public float X { get; private set; }
        public float Y { get; private set; }
        public float Z { get;private set; }
        public float Heading { get; private set; }
        public float Pitch { get; private set; }
        public float Roll { get; private set; }

        public Ets2Placement(float x, float y, float z, float heading, float pitch, float roll)
        {
            X = x;
            Y = y;
            Z = z;
            Heading = heading;
            Pitch = pitch;
            Roll = roll;
        }
    }
}
