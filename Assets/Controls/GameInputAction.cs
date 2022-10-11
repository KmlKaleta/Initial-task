using System;

namespace Game
{
    public abstract class GameInputAction
    {
        public event Action OnClick;

        protected void InvokeOnClick() => OnClick?.Invoke();
    }

    public abstract class GameInputAction<T> where T : struct
    {
        public event Action<T> OnUpdate;

        protected void InvokeOnUpdate(T value) => OnUpdate?.Invoke(value);
    }
}
