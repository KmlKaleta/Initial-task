using UnityEngine;

namespace Game
{
    public sealed class ItemStack
    {
        public ItemSO Item { get; }

        public byte Amount { get; private set; }

        public bool IsFull { get; set; }

        public bool TryAdd(out int reminder, int amount = 1)
        {
            byte maxAmountInStack = Item.MaxAmountInStack;
            reminder = maxAmountInStack - amount - Amount;

            if (reminder < 0)
            {
                reminder = Mathf.Abs(reminder);
                Amount = maxAmountInStack;
                IsFull = true;
                return false;
            }

            Amount += (byte)amount;
            IsFull = Amount == maxAmountInStack;
            return true;
        }

        public ItemStack(ItemSO item, byte amount)
        {
            Item = item;
            Amount = amount;
        }

        public override string ToString()
        {
            return Item.name + " " + Amount;
        }

        public void Substract(byte amount = 1)
        {
            Amount -= amount;
            IsFull = Amount == Item.MaxAmountInStack;
        }
    }
}