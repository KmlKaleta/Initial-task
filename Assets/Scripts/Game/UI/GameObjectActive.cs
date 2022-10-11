using UnityEngine;
using Utility;

namespace Game.UI
{
    public sealed class GameObjectActive : IValueHolder<bool>
    {
        private readonly GameObject _gameObject;
        private bool _isActive;

        public GameObjectActive(GameObject gameObject)
        {
            _gameObject = gameObject;
            _isActive = gameObject.activeSelf;
        }

        public bool Value
        {
            get => _isActive; 
            set
            {
                if (value != _isActive)
                {
                    _isActive = value;
                    _gameObject.SetActive(value);
                }

            }
        }
    }
}
