using System;
using UnityEngine;

namespace Game
{
    public static class GameManager 
    {
        public static bool IsPaused { get; private set; }

        private static Action _resumeAction;

        public static void Resume()
        {
            if (!IsPaused)
            {
                return;
            }

            Controls.Game.Enable();
            Controls.Pause.Disable();
            IsPaused = false;
            Cursor.lockState = CursorLockMode.Locked;
            _resumeAction();
        }

        public static void Pause(Action resume)
        {
            if (IsPaused)
            {
                return;
            }

            Controls.Game.Disable();
            Controls.Pause.Enable();
            IsPaused = true;
            Cursor.lockState = CursorLockMode.None;
            _resumeAction = resume;
        }
    }
}
