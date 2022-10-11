using System.Collections.Generic;

namespace Game.UI
{
    public interface IInventoryItems<TItem> where TItem : ItemUIBase
    {
        void Update(IEnumerator<ItemStack> stacks);
    }
}