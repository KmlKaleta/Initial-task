using System.Collections.Generic;
using UnityEngine;
using Utility;

namespace Game
{
    [RequireComponent(typeof(CharacterController))]
    public sealed class PlayerController : MonoBehaviour
    {
        [System.Serializable]
        private class ItemAmountPair
        {
            [field: SerializeField] public ItemSO Item { get; private set; }
            [field: SerializeField, Min(1)] public int Amount { get; private set; }
        }

        [SerializeField] private List<ItemAmountPair> startItems;
        [SerializeField, Min(0)] private int startGold = 200;

        private IPlayerMovement _movement;
        private IPlayerInteractions _interactions;

        private static IInventory _inventory;

        private readonly struct SensitivityGetter : IValueGetter<float>
        {
            public float Value => Settings.Sensitivity;
        }

        private void Awake()
        {
            Cursor.lockState = CursorLockMode.Locked;
            _movement = new PlayerMovement(
                new TransformHolder(transform),
                new TransformHolder(Camera.main.transform),
                new CharacterControllerHolder(GetComponent<CharacterController>()),
                new GameTime(),
                10,
                new SensitivityGetter(),
                -60,
                60
                );
            _movement.SubscribeMoveInput(new DirectionInputActionFixedUpdate<Vector2>(Controls.Game.Movement));
            _movement.SubscribeRotationInput(new ClickValueInputAction<Vector2>(Controls.Game.CursorDelta));

            _interactions = new PlayerInteractions(new MainCamera(), 5);
            _interactions.SubscribeInteractionInput(new ClickInputAction(Controls.Game.LeftClick));
        }

        private void Start()
        {
            _inventory = new Inventory();
            for (int i = 0; i < startItems.Count; i++)
            {
                var itemToAdd = startItems[i];
                _inventory.AddItem(itemToAdd.Item, itemToAdd.Amount);
            }

            _inventory.Gold = startGold;
        }

        public static void AddGold(int amount)
        {
            _inventory.Gold += amount;
        }

        public static bool TryGetGold(int amount)
        {
            if (_inventory.Gold < amount)
            {
                return false;
            }

            _inventory.Gold -= amount;
            return true;
        }

        public static void AddItem(ItemSO item, int amount = 1)
        {
            _inventory.AddItem(item, amount);
        }

        public static void DecreaseAmountOfItemAt(int index)
        {
            _inventory.DecreaseAmountOfItemAt(index);
        }
    }
}
