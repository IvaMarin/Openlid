using Cinemachine;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(StarterAssetsInputs))]
public class PauseMenu : MonoBehaviour
{
    private enum InputActionMap
    {
        Player,
        UI
    }

    public static bool isGamePaused = false;

    public GameObject pauseMenuUI;
    public GameObject controlsMenuUI;
    public GameObject audioMenuUI;
    public GameObject dreamSelectionMenuUI;

    [SerializeField]
    private GameObject _player;

    private StarterAssetsInputs _input;
    private PlayerInput _playerInput;

    private void Awake()
    {
        _input = _player.GetComponent<StarterAssetsInputs>();
        _playerInput = _player.GetComponent<PlayerInput>();
    }

    private void Update()
    {
        if (isGamePaused)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        if (_input.pause)
        {
            if (isGamePaused)
            {
                HideUI();
                Resume();
            }
            else
            {
                pauseMenuUI.SetActive(true);
                Pause();
            }
            _input.pause = false;
        }
    }

    private void HideUI()
    {
        pauseMenuUI.SetActive(false);

        if (audioMenuUI != null && audioMenuUI.activeSelf)
        {
            audioMenuUI.SetActive(false);
        }

        if (controlsMenuUI != null && controlsMenuUI.activeSelf)
        {
            controlsMenuUI.SetActive(false);
            controlsMenuUI.GetComponent<SettingsMenu>().UpdateUISettingsValues();
        }

        if (dreamSelectionMenuUI != null && dreamSelectionMenuUI.activeSelf)
        {
            dreamSelectionMenuUI.SetActive(false);
        }
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        _playerInput.SwitchCurrentActionMap(InputActionMap.Player.ToString());
        Cursor.visible = false;
        isGamePaused = false;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        _playerInput.SwitchCurrentActionMap(InputActionMap.UI.ToString());
        isGamePaused = true;
    }
}
