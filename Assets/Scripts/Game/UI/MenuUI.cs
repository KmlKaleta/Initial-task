using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace Game.UI
{
    public sealed class MenuUI : MonoBehaviour
    {
        [SerializeField] private Button quit;
        [SerializeField] private TMP_Dropdown resolution;
        [SerializeField] private TMP_Dropdown quality;
        [SerializeField] private Toggle fullscreen;
        [SerializeField] private Slider sensitivity;

        private void Awake()
        {
            quit.onClick.AddListener(
#if !UNITY_EDITOR
                Application.Quit
#else
                () => UnityEditor.EditorApplication.isPlaying = false
#endif
                );

            Controls.Game.Exit.started += Show;

            fullscreen.isOn = Screen.fullScreen;
            fullscreen.onValueChanged.AddListener(ChangeFullScreen);

            quality.value = QualitySettings.GetQualityLevel();
            quality.onValueChanged.AddListener(ChangeQuality);

            resolution.FillResolutions(r => r.width + "x" + r.height + "x" + r.refreshRate);
            resolution.onValueChanged.AddListener(ChangeResolution);

            Settings.Sensitivity = 10;
            sensitivity.value = Settings.Sensitivity;
            sensitivity.onValueChanged.AddListener(ChangeSensitivity);

            gameObject.SetActive(false);
        }

        private void ChangeSensitivity(float value) => Settings.Sensitivity = value;

        private void ChangeResolution(int index)
        {
            var resolution = Screen.resolutions[index];
            Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        }

        private void ChangeQuality(int level) => QualitySettings.SetQualityLevel(level);

        private void ChangeFullScreen(bool value) => Screen.fullScreen = value;

        private void Show(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            gameObject.SetActive(true);
            GameManager.Pause(Hide);
        }

        private void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
