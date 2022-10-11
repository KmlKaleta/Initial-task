using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace Game.UI
{
    public abstract class ItemUIBase : MonoBehaviour
    {
        [SerializeField] protected Image image;

        private IValueHolder<bool> _active;

        public virtual void Init()
        {
            _active = new GameObjectActive(gameObject);
        }

        public virtual ItemStack Stack
        {
            set
            {
                image.sprite = value.Item.Sprite;
            }
        }

        public int Index { get; set; }

        public void Show()
        {
            _active.Value = true;
        }

        public virtual void Hide()
        {
            _active.Value = false;
        }
    }
}
