namespace Utility
{
    public interface IValueGetter<out T>
    {
        public T Value { get; }
    }
}
