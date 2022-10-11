using UnityEngine;

namespace Game
{
    public interface IPlayerMovement
    {
        void SubscribeMoveInput(GameInputAction<Vector2> input);

        void SubscribeRotationInput(GameInputAction<Vector2> input);
    }
}