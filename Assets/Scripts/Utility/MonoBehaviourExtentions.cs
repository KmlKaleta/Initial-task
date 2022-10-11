using System;
using UnityEngine;

namespace Utility
{
    public class MonoBehaviourExtentions
    {
        public static GameObject CreateInstance(string name = "NewGameObject")
        {
            return new(name);
        }

        public static T CreateInstance<T>() where T : MonoBehaviour
        {
            Type type = typeof(T);
            return new GameObject(type.Name, type).GetComponent<T>();
        }
    }
}