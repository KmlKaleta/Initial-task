using UnityEngine;

namespace Game
{
    public readonly struct MainCamera : ICamera
    {
        public bool TryGetHit(Vector2 screenPoint, out RaycastHit hit, int layerMask = -1, float maxDistance = float.MaxValue)
        {
            return Physics.Raycast(Camera.main.ScreenPointToRay(screenPoint), out hit, maxDistance, layerMask);
        }
    }
}
