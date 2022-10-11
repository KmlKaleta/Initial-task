using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public sealed class Trader : Interactable
    {
        public static event Action<IEnumerable<ItemStack>> OnStartTrading;

        [SerializeField] private MeshRenderer meshRenderer;
        [SerializeField] private Color hoverColor = Color.yellow;
        [SerializeField] private ItemSO[] sellingItems;

        private ItemStack[] _itemsToSell;
        private Color _defaultColor;

        private void Awake()
        {
            _defaultColor = meshRenderer.material.color;

            int length = sellingItems.Length;
            _itemsToSell = new ItemStack[length];

            for (int i = 0; i < length; i++)
            {
                _itemsToSell[i] = new(sellingItems[i], 0);
            }
        }

        public override void Interact()
        {
            OnStartTrading?.Invoke(_itemsToSell);
        }

        public override void StartHover()
        {
            meshRenderer.material.color = hoverColor;
        }

        public override void StopHover()
        {
            meshRenderer.material.color = _defaultColor;
        }
    }
}
