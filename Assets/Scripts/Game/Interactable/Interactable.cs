using UnityEngine;

namespace Game
{
    public abstract class Interactable : MonoBehaviour
    {
        public bool CanInteract { get; protected set; } = true;

        public abstract void StartHover();

        public abstract void StopHover();

        public abstract void Interact();
    }
}
