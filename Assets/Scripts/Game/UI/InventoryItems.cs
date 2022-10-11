using System.Collections.Generic;
using UnityEngine;

namespace Game.UI
{
    public class InventoryItems<TItem> : IInventoryItems<TItem> where TItem : ItemUIBase
    {
        private readonly Transform _itemsParent;
        private readonly TItem _firstItem;
        private readonly IList<TItem> _items;

        public InventoryItems(TItem firstItem, Transform itemsParent)
        {
            _itemsParent = itemsParent;

            this._firstItem = firstItem;
            _items = new List<TItem>()
            {
                firstItem
            };

            firstItem.Init();
            firstItem.Hide();
        }

        public void Update(IEnumerator<ItemStack> stacks)
        {
            int i = 0;
            while (stacks.MoveNext())
            {
                ShowItem(stacks, ref i);
            }
            stacks.Reset();

            for (; i < _items.Count; i++)
            {
                _items[i].Hide();
            }
        }

        private void ShowItem(IEnumerator<ItemStack> stacks, ref int i)
        {
            TItem item = null;
            if (_items.Count <= i)
            {
                item = Object.Instantiate(_firstItem, _itemsParent);
                item.Init();
                _items.Add(item);
            }

            item ??= _items[i];
            item.Show();
            item.Stack = stacks.Current;
            item.Index = i;
            i++;
        }
    }
}