using TMPro;
using UnityEngine;

namespace Game.UI
{
    public sealed class GoldUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textMesh;

        private void Awake()
        {
            Inventory.OnGoldAmountChange += OnGoldAmountChangeHandle;
        }

        private void OnGoldAmountChangeHandle(int amount)
        {
            textMesh.text = amount.ToString();
        }
    }
}
