namespace Utility
{
    public interface IValueHolder<T>
    {
        T Value { get; set; }
    }
}