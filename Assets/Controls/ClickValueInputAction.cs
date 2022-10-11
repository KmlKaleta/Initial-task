using UnityEngine.InputSystem;

namespace Game
{
    public sealed class ClickValueInputAction<T> : GameInputAction<T> where T : struct
    {
        public ClickValueInputAction(InputAction input)
        {
            input.started += ClickHandle;
        }

        private void ClickHandle(InputAction.CallbackContext context)
        {
            InvokeOnUpdate(context.ReadValue<T>());
        }
    }
}
