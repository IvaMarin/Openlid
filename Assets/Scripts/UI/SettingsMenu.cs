using StarterAssets;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [Header("Settings UI Elements")]

    [SerializeField]
    private Slider _sensitivitySlider;

    private void Start()
    {
        UpdateUISettingsValues();
    }

    public void ApplyChanges()
    {
        ThirdPersonController.CameraSensitivity = _sensitivitySlider.value;
    }

    public void UpdateUISettingsValues()
    {
        _sensitivitySlider.value = ThirdPersonController.CameraSensitivity;
    }
}
