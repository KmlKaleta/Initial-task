using TMPro;
using UnityEngine;

namespace Game.UI
{
    public sealed class SellItemUI : TradeItemUI
    {
        [SerializeField] private TextMeshProUGUI textMesh;

        private sealed class SellPriceShower : PriceShower
        {
            protected override void ResetPrice() => Shop.ResetSellPriceText();

            protected override void SetPrice(int price) => Shop.SetSellPriceText(price);
        }

        public override ItemStack Stack
        {
            set
            {
                base.Stack = value;
                textMesh.text = value.Amount.ToString();
                button.onClick.AddListener(() =>
                {
                    PlayerController.DecreaseAmountOfItemAt(Index);
                    PlayerController.AddGold(value.Item.Price);
                });
            }
        }

        protected override IPriceShower GetPriceShower() => new SellPriceShower();
    }
}