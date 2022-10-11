using UnityEngine;
using Utility;

namespace Game
{
    public readonly struct GameTime : ITime
    {
        public float DeltaTime => Time.deltaTime;

        public float FixedDeltaTime => Time.fixedDeltaTime;
    }
}
