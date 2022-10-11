using TMPro;
using UnityEngine;

namespace Game.UI
{
    public sealed class ItemUI : ItemUIBase
    {
        [SerializeField] private TextMeshProUGUI textMesh;

        public override ItemStack Stack
        {
            set
            {
                base.Stack = value;
                textMesh.text = value.Amount.ToString();
            }
        }
    }
}