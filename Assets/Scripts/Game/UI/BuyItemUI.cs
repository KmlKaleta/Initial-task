using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Utility;

namespace Game.UI
{
    public sealed class BuyItemUI : TradeItemUI
    {
        private sealed class BuyPriceShower : PriceShower
        {
            protected override void ResetPrice() => Shop.ResetBuyPriceText();

            protected override void SetPrice(int price) => Shop.SetBuyPriceText(price);
        }

        public override ItemStack Stack
        {
            set
            {
                base.Stack = value;
                button.onClick.AddListener(() =>
                {
                    var item = value.Item;

                    if (PlayerController.TryGetGold(item.Price))
                    {
                        PlayerController.AddItem(item);
                    }
                });
            }
        }

        protected override IPriceShower GetPriceShower() => new BuyPriceShower();
    }
}