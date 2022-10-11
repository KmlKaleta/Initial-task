using UnityEngine.InputSystem;

namespace Game.UI
{
    public sealed class InventoryUI : InventoryUIBase<ItemUI>
    {
        protected override void Awake()
        {
            base.Awake();
            Controls.Game.Inventory.started += Enable;
            Controls.Pause.Inventory.started += Disable;
        }

        private void Disable(InputAction.CallbackContext context)
        {
            GameManager.Resume();
            Disable();
        }

        private void Enable(InputAction.CallbackContext context)
        {
            Enable();
        }
    }
}
