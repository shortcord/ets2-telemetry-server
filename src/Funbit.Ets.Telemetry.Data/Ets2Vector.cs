namespace Funbit.Ets.Telemetry.Data
{
    public sealed class Ets2Vector
    {
        public float X { get; }
        public float Y { get; }
        public float Z { get; }

        public Ets2Vector(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}
