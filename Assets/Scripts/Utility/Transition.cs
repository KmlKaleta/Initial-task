using System;
using UnityEngine;

namespace Utility
{
    public sealed class Transition
    {
        public event Action OnEnd;

        public float MaxTime { get; set; }

        public bool Reversed { get; set; }

        private readonly AnimationCurve _curve;
        private readonly Action<float> _transition;
        private readonly ITime _time;
        private float _currentTime;


        public Transition(Action<float> transition, ITime time, AnimationCurve curve, float maxTime)
        {
            _curve = curve ?? AnimationCurve.EaseInOut(0, 0, 1, 1);
            MaxTime = maxTime;
            _transition = transition;
            _time = time;
        }

        public void Start()
        {
            _currentTime = 0;
            UpdateHook.ResetListener(Update);
        }

        public void Start(float newMaxTime)
        {
            MaxTime = newMaxTime;
            Start();
        }

        private void Update()
        {
            if (_currentTime >= MaxTime)
            {
                UpdateHook.RemoveListener(Update);
                _transition(_curve.Evaluate(Reversed ? 0 : 1));
                OnEnd?.Invoke();
                return;
            }

            _currentTime += _time.DeltaTime;
            float t = _currentTime / MaxTime;
            _transition(_curve.Evaluate(Reversed ? 1 - t : t));
        }

        public void Stop()
        {
            UpdateHook.RemoveListener(Update);
        }
    }
}
