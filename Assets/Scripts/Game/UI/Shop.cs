using TMPro;
using UnityEngine;

namespace Game.UI
{
    public sealed class Shop : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI buyPriceText;
        [SerializeField] private TextMeshProUGUI sellPriceText;

        private static Shop _instance;

        const string NO_SELECTED_ITEM = "-";

        private void Awake()
        {
            _instance = this;
            ResetSellPriceText();
            ResetBuyPriceText();
        }

        public static void SetBuyPriceText(int price)
        {
            _instance.buyPriceText.text = price.ToString();
        }

        public static void ResetBuyPriceText()
        {
            _instance.buyPriceText.text = NO_SELECTED_ITEM;
        }

        public static void SetSellPriceText(int price)
        {
            _instance.sellPriceText.text = price.ToString();
        }

        public static void ResetSellPriceText()
        {
            _instance.sellPriceText.text = NO_SELECTED_ITEM;
        }
    }
}
