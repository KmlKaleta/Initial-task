namespace Utility
{
    public abstract class ObjectHolder<T> where T : class
    {
        protected readonly T _object;

        protected ObjectHolder(T obj)
        {
            _object = obj;
        }
    }
}
