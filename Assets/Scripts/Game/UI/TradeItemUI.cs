using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Game.UI
{
    public abstract class TradeItemUI : ItemUIBase, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] protected Button button;

        private IPriceShower _isPointerOn;

        protected interface IPriceShower
        {
            ItemSO Item { set; }

            public bool Value { get; set; }
        }

        protected abstract class PriceShower : IPriceShower
        {
            public ItemSO Item { private get; set; }

            private bool _value;

            public bool Value
            {
                get => _value;
                set
                {
                    if (value == _value)
                    {
                        return;
                    }

                    _value = value;

                    if (_value)
                    {
                        SetPrice(Item.Price);
                        return;
                    }
                    ResetPrice();
                }
            }

            protected abstract void SetPrice(int price);

            protected abstract void ResetPrice();
        }

        public override void Init()
        {
            base.Init();
            _isPointerOn = GetPriceShower();
        }

        protected abstract IPriceShower GetPriceShower();

        public override ItemStack Stack
        {
            set
            {
                base.Stack = value;
                _isPointerOn.Item = value.Item;
                button.onClick.RemoveAllListeners();
            }
        }

        public override void Hide()
        {
            base.Hide();
            _isPointerOn.Value = false;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _isPointerOn.Value = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _isPointerOn.Value = false;
        }
    }
}
