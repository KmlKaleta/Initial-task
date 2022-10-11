using UnityEngine;

namespace Game
{
    public sealed class Gold : Interactable
    {
        [SerializeField] private int amount = 50;

        public override void Interact()
        {
            PlayerController.AddGold(amount);
            gameObject.SetActive(false);
        }

        public override void StartHover()
        {
        }

        public override void StopHover()
        {
        }
    }
}
