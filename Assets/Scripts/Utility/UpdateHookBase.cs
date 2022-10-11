using System;
using UnityEngine;

namespace Utility
{
    public class UpdateHookBase<T> : MonoBehaviour where T : UpdateHookBase<T>
    {
        private struct Active : IValueHolder<bool>
        {
            private bool _isActive;

            public bool Value
            {
                get => _isActive;
                set
                {
                    _isActive = value;
                    _instance.gameObject.SetActive(value);
                }
            }
        }

        private event Action OnUpdate;

        private static readonly T _instance;

        private readonly IValueHolder<bool> _active = new Active();

        static UpdateHookBase()
        {
            _instance = MonoBehaviourExtentions.CreateInstance<T>();
            DontDestroyOnLoad(_instance.gameObject);
        }

        public static void AddListener(Action listener)
        {
            _instance.OnUpdate += listener;

            if (!_instance._active.Value)
            {
                _instance._active.Value = true;
            }
        }

        public static void ResetListener(Action listener)
        {
            _instance.OnUpdate -= listener;
            AddListener(listener);
        }

        public static void RemoveListener(Action listener)
        {
            _instance.OnUpdate -= listener;

            if (_instance.OnUpdate is null && _instance._active.Value)
            {
                _instance._active.Value = false;
            }
        }

        protected void InvokeUpdate() => OnUpdate();
    }
}
