using UnityEngine;

namespace Game
{
    public static class Controls
    {
        private static readonly PlayerInputs _inputs;

        static Controls()
        {
            _inputs = new();
            _inputs.Game.Enable();
        }

        public static PlayerInputs.GameActions Game => _inputs.Game;
        
        public static PlayerInputs.PauseActions Pause => _inputs.Pause;
    }
}
