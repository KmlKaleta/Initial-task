using UnityEngine.InputSystem;
using Utility;

namespace Game
{
    public sealed class DirectionInputActionFixedUpdate<T> : GameInputAction<T> where T : struct
    {
        private readonly InputAction _input;

        public DirectionInputActionFixedUpdate(InputAction input)
        {
            _input = input;
            _input.started += StartActionHandle;
            _input.canceled += StopActionHandle;
        }

        private void StartActionHandle(InputAction.CallbackContext context)
        {
            FixedUpdateHook.AddListener(UpdateInput);
        }

        private void StopActionHandle(InputAction.CallbackContext context)
        {
            FixedUpdateHook.RemoveListener(UpdateInput);
        }

        private void UpdateInput()
        {
            InvokeOnUpdate(_input.ReadValue<T>());
        }
    }
}
