using System;
using UnityEngine;
using Utility;

namespace Game
{
    public sealed class PlayerInteractions : IPlayerInteractions
    {
        private readonly ICamera _camera;
        private readonly float _maxInteractDistance;
        private Interactable _interactableUnderCursor;

        public PlayerInteractions(ICamera camera, float maxInteractDistance)
        {
            _camera = camera;
            _maxInteractDistance = maxInteractDistance;
            UpdateHook.AddListener(Update);
        }

        private void Update()
        {
            if (_camera.TryGetComponentInHittedCollider(new Vector2(Screen.width / 2, Screen.height / 2), out InteractableCollider collider, Physics.AllLayers, _maxInteractDistance))
            {
                UpdateInteractable(collider);
                return;
            }

            if (_interactableUnderCursor is not null)
            {
                _interactableUnderCursor.StopHover();
                _interactableUnderCursor = null;
            }
        }

        private void UpdateInteractable(InteractableCollider collider)
        {
            Interactable interactable = collider.Interactable;
            if (interactable != _interactableUnderCursor)
            {
                _interactableUnderCursor?.StopHover();

                _interactableUnderCursor = interactable;
                interactable.StartHover();
            }
        }

        public void SubscribeInteractionInput(GameInputAction input)
        {
            input.OnClick += ClickHandle;
        }

        private void ClickHandle()
        {
            _interactableUnderCursor?.Interact();
        }
    }
}
