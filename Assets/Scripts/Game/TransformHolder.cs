using UnityEngine;
using Utility;

namespace Game
{
    public sealed class TransformHolder : ObjectHolder<Transform>, ITransform
    {
        public TransformHolder(Transform transform) : base(transform)
        { }

        public Vector3 Foward { get => _object.forward; set => _object.forward = value; }

        public Vector3 Right { get => _object.right; set => _object.right = value; }

        public Vector3 EulerAngles { get => _object.eulerAngles; set => _object.eulerAngles = value; }

        public Vector3 LocalEulerAngles { get => _object.localEulerAngles; set => _object.localEulerAngles = value; }
    }
}
