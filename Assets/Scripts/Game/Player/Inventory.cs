using System;
using System.Collections.Generic;

namespace Game
{
    public sealed class Inventory : IInventory
    {
        public static event Action<IEnumerator<ItemStack>> OnChange;
        public static event Action<int> OnGoldAmountChange;

        private readonly IList<ItemStack> _items;

        public Inventory()
        {
            _items = new List<ItemStack>();
        }

        private int _gold;

        public int Gold
        {
            get => _gold;
            set
            {
                _gold = value;
                OnGoldAmountChange?.Invoke(_gold);
            }
        }

        public void AddItem(ItemSO item, int amount)
        {
            if (amount <= 0)
            {
                throw new System.Exception("Amount can't be under or equal 0!");
            }

            for (int i = 0; i < _items.Count; i++)
            {
                var stack = _items[i];

                if (!stack.IsFull && stack.Item == item && stack.TryAdd(out amount, amount))
                {
                    OnChange?.Invoke(_items.GetEnumerator());
                    return;
                }
            }

            while (amount > item.MaxAmountInStack)
            {
                _items.Add(new(item, item.MaxAmountInStack));
                amount -= item.MaxAmountInStack;
            }

            _items.Add(new(item, (byte)amount));

            OnChange?.Invoke(_items.GetEnumerator());
        }

        public void DecreaseAmountOfItemAt(int index)
        {
            var stack = _items[index];

            stack.Substract();

            if (stack.Amount <= 0)
            {
                _items.RemoveAt(index);
            }

            OnChange?.Invoke(_items.GetEnumerator());
        }
    }
}
