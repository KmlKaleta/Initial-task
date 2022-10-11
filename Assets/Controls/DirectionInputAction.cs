using UnityEngine.InputSystem;
using Utility;

namespace Game
{
    public sealed class DirectionInputAction<T> : GameInputAction<T> where T : struct
    {
        private readonly InputAction _input;

        public DirectionInputAction(InputAction input)
        {
            _input = input;
            _input.started += StartActionHandle;
            _input.canceled += StopActionHandle;
        }

        private void StartActionHandle(InputAction.CallbackContext context)
        {
            UpdateHook.AddListener(UpdateInput);
        }

        private void StopActionHandle(InputAction.CallbackContext context)
        {
            UpdateHook.RemoveListener(UpdateInput);
        }

        private void UpdateInput()
        {
            InvokeOnUpdate(_input.ReadValue<T>());
        }
    }
}
