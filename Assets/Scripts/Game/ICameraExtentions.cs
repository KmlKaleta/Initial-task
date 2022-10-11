using UnityEngine;

namespace Game
{
    public static class ICameraExtentions
    {
        public static bool TryGetPosition(this ICamera camera, Vector2 screenPoint, out Vector3 position, int layerMask = -1, float maxDistance = float.MaxValue)
        {
            bool isRaycastHitted = camera.TryGetHit(screenPoint, out RaycastHit hit, layerMask, maxDistance);
            position = hit.point;
            return isRaycastHitted;
        }

        public static bool TryGetComponentInHittedCollider<T>(this ICamera camera, Vector2 screenPoint, out T component, int layerMask = -1, float maxDistance = float.MaxValue) where T : class
        {
            bool isRaycastHitted = camera.TryGetHit(screenPoint, out RaycastHit hit, layerMask, maxDistance);
            component = isRaycastHitted ? hit.collider.GetComponent<T>() : null;
            return isRaycastHitted && component is not null;
        }
    }
}
