using UnityEngine;

namespace Game
{
    public interface ICamera
    {
        bool TryGetHit(Vector2 screenPoint, out RaycastHit hit, int layerMask = Physics.AllLayers, float maxDistance = float.MaxValue);
    }
}
