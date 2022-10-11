using UnityEngine;

namespace Game
{
    public interface ITransform
    {
        Vector3 Foward { get; set; }

        Vector3 Right { get; set; }

        Vector3 EulerAngles { get; set; }

        Vector3 LocalEulerAngles { get; set; }
    }
}
