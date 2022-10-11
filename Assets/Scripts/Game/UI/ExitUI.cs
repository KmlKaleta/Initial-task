using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public class ExitUI : MonoBehaviour
    {
        [SerializeField] private Button button;

        private void Awake()
        {
            button.onClick.AddListener(Exit);

            Controls.Pause.Exit.performed += Exit;
        }

        private void Exit(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            Exit();
        }

        private void Exit()
        {
            GameManager.Resume();
        }
    }
}
