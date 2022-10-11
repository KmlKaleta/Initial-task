namespace Utility
{
    public interface ITime
    {
        float DeltaTime { get; }

        float FixedDeltaTime { get; }
    }
}
