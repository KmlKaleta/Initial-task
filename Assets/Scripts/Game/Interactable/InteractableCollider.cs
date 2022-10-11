using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(Collider))]
    public class InteractableCollider : MonoBehaviour
    {
        [field: SerializeField] public Interactable Interactable { get; private set; }
    }
}