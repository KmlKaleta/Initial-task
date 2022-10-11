using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Utility;

namespace Game.UI
{
    public abstract class InventoryUIBase<TItem> : MonoBehaviour where TItem : ItemUIBase
    {
        [SerializeField] private Transform itemsParent;
        [SerializeField] private TItem firstItem;

        private IInventoryItems<TItem> _items;
        protected IValueHolder<bool> _active;

        protected virtual void Awake()
        {
            _items = new InventoryItems<TItem>(firstItem, itemsParent);

            Inventory.OnChange += _items.Update;

            _active = new GameObjectActive(gameObject)
            {
                Value = false
            };
        }

        protected void Enable()
        {
            GameManager.Pause(Disable);
            _active.Value = true;
        }

        protected void Disable()
        {
            if (_active.Value)
            {
                _active.Value = false;
            }
        }
    }
}
