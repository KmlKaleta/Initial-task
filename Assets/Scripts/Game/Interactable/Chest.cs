using UnityEngine;
using Utility;

namespace Game
{
    public sealed class Chest : Interactable
    {
        [SerializeField] private AnimationCurve openCurve = AnimationCurve.Linear(0, 0, 1, 1);
        [SerializeField] private Transform open;
        [SerializeField] private float openedXRotation = 90;
        [SerializeField, Min(0)] private float openTime = 2;
        [SerializeField] private float hoveredXRotation = 10;

        private Transition _openTransition;
        private Transition _hoverTransition;
        private float _closedXRotation;
        private float _startHoverXRotation;
        private float _endHoverXRotation;

        private void Awake()
        {
            _openTransition = new Transition(UpdateOpen, new GameTime(), openCurve, openTime);
            _hoverTransition = new Transition(UpdateHover, new GameTime(), openCurve, openTime * 0.25f);
        }

        public override void Interact()
        {
            if (!CanInteract)
            {
                return;
            }

            CanInteract = false;
            _closedXRotation = open.localEulerAngles.x;
            _hoverTransition.Stop();
            _openTransition.Start();
        }

        private void UpdateOpen(float t)
        {
            SetOpenX(Mathf.Lerp(_closedXRotation, openedXRotation, t));
        }

        public override void StartHover()
        {
            if (!CanInteract)
            {
                return;
            }

            _hoverTransition.Reversed = false;
            _startHoverXRotation = open.localEulerAngles.x;
            _hoverTransition.Start();
        }

        private void UpdateHover(float t)
        {
            SetOpenX(GetHoverXRotation(t));
        }

        private void SetOpenX(float rotationX)
        {
            var eulerAngles = open.localEulerAngles;
            eulerAngles.x = rotationX;
            open.localEulerAngles = eulerAngles;
        }

        private float GetHoverXRotation(float t)
        {
            return _hoverTransition.Reversed ?
                Mathf.Lerp(0, _endHoverXRotation, t) :
                Mathf.Lerp(_startHoverXRotation, hoveredXRotation, t);
        }

        public override void StopHover()
        {
            if (!CanInteract)
            {
                return;
            }

            _hoverTransition.Reversed = true;
            _endHoverXRotation = open.localEulerAngles.x;
            _hoverTransition.Start();
        }
    }
}
