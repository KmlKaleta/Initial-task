using UnityEngine;

namespace Game
{
    public sealed class Item : Interactable
    {
        [SerializeField] private ItemSO item;
        [SerializeField, Min(1)] private byte amount = 1;

        public override void Interact()
        {
            PlayerController.AddItem(item, amount);
            gameObject.SetActive(false);
        }

        public override void StartHover()
        { }

        public override void StopHover()
        { }
    }
}
