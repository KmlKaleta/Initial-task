using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "NewItem", menuName = "Scriptable Objects/Item")]
    public sealed class ItemSO : ScriptableObject
    {
        [field: SerializeField, Min(1)] public byte MaxAmountInStack { get; private set; } = 64;

        [field: SerializeField, Min(0)] public int Price { get; private set; } = 200;

        [field: SerializeField] public Sprite Sprite { get; private set; }
    }
}