using UnityEngine.InputSystem;

namespace Game
{
    public class ClickInputAction : GameInputAction
    {
        public ClickInputAction(InputAction input)
        {
            input.started += ClickHandle;
        }

        private void ClickHandle(InputAction.CallbackContext obj)
        {
            InvokeOnClick();
        }
    }
}
