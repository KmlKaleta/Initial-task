using System.Collections.Generic;
using UnityEngine;

namespace Game.UI
{
    public sealed class TradeUI : InventoryUIBase<SellItemUI>
    {
        [SerializeField] private BuyItemUI firstBuyItem;
        [SerializeField] private Transform buyItemsParent;

        private IInventoryItems<BuyItemUI> _buyItems;

        protected override void Awake()
        {
            base.Awake();
            _buyItems = new InventoryItems<BuyItemUI>(firstBuyItem, buyItemsParent);
            Trader.OnStartTrading += Enable;
        }

        private void Enable(IEnumerable<ItemStack> items)
        {
            base.Enable();
            _buyItems.Update(items.GetEnumerator());
        }
    }
}
