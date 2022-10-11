using UnityEngine;

namespace Utility
{
    public static class VectorExtentions
    {
        public static Vector3 ToVector3XZ(this Vector2 vector, float y = 0) => new(vector.x, y, vector.y);
    }
}
