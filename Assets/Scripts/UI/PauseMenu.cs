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
                Resume();
            }
            else
            {
                Pause();
            }
            _input.pause = false;
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);

        if (audioMenuUI.activeSelf)
        {
            audioMenuUI.SetActive(false);
        }

        if (controlsMenuUI.activeSelf)
        {
            controlsMenuUI.SetActive(false);
            controlsMenuUI.GetComponent<SettingsMenu>().UpdateUISettingsValues();
        }

        //pauseMenuUI.GetComponent<Animator>().enabled = true;

        Time.timeScale = 1f;
        _playerInput.SwitchCurrentActionMap(InputActionMap.Player.ToString());
        Cursor.visible = false;
        isGamePaused = false;
    }

    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        _playerInput.SwitchCurrentActionMap(InputActionMap.UI.ToString());
        isGamePaused = true;
    }
}
