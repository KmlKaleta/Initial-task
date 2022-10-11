using UnityEngine;
using Utility;

namespace Game
{
    public sealed class PlayerMovement : IPlayerMovement
    {
        private readonly ITransform _playerTransform;
        private readonly ITransform _cameraTransform;
        private readonly ICharacterController _characterController;
        private readonly ITime _time;
        private readonly float _moveSpeed;
        private readonly IValueGetter<float> _sensitivity;
        private readonly float _cameraRotationXMin;
        private readonly float _cameraRotationXMax;
        private float _cameraRotationX;

        public PlayerMovement(ITransform playerTransform, ITransform cameraTransform, ICharacterController characterController, ITime time, float moveSpeed, IValueGetter<float> sensitivity, float cameraRotationXMin, float cameraRotationXMax)
        {
            _playerTransform = playerTransform;
            _cameraTransform = cameraTransform;
            _characterController = characterController;
            _time = time;
            _moveSpeed = moveSpeed;
            _sensitivity = sensitivity;
            _cameraRotationXMin = cameraRotationXMin;
            _cameraRotationXMax = cameraRotationXMax;
            _cameraRotationX = cameraTransform.LocalEulerAngles.x;
        }

        public void SubscribeMoveInput(GameInputAction<Vector2> input)
        {
            input.OnUpdate += Move;
        }

        private void Move(Vector2 movement)
        {
            var direction = movement.y * _playerTransform.Foward + movement.x * _playerTransform.Right;
            direction.y = -1;
            _characterController.Move(_moveSpeed * _time.FixedDeltaTime * direction);
        }

        public void SubscribeRotationInput(GameInputAction<Vector2> input)
        {
            input.OnUpdate += Rotate;
        }

        private void Rotate(Vector2 rotation)
        {
            if (rotation.x != 0)
            {
                var eulerAngles = _playerTransform.EulerAngles;
                eulerAngles.y += rotation.x * _time.DeltaTime * _sensitivity.Value;
                _playerTransform.EulerAngles = eulerAngles;
            }

            if (rotation.y != 0)
            {
                float xAfterRotation = _cameraRotationX + rotation.y * _time.DeltaTime * _sensitivity.Value;
                _cameraRotationX = Mathf.Clamp( xAfterRotation, _cameraRotationXMin, _cameraRotationXMax);
                _cameraTransform.LocalEulerAngles = new Vector3(xAfterRotation, 0, 0);
            }
        }
    }
}