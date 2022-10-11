using System;
using System.Collections.Generic;

namespace Game
{
    public interface IInventory
    {
        int Gold { get; set; }

        void AddItem(ItemSO item, int amount);

        void DecreaseAmountOfItemAt(int index);
    }
}
