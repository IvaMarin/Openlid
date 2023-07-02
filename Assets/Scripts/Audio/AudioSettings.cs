using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    [SerializeField]
    private AudioMixer _audioMixer;

    [SerializeField]
    private Slider _masterVolumeSlider;

    [SerializeField]
    private Slider _musicVolumeSlider;

    [SerializeField]
    private Slider _soundsVolumeSlider;


    private void Awake()
    {
        ListenToSliders();
    }

    private void Start()
    {
        SetSliderValues();
    }

    private void OnDisable()
    {
        SaveSliderValues();
    }

    private void ListenToSliders()
    {
        _masterVolumeSlider.onValueChanged.AddListener((value) =>
        {
            SetVolume(AudioManager.Volume.MasterVolume, value);
        });
        _musicVolumeSlider.onValueChanged.AddListener((value) =>
        {
            SetVolume(AudioManager.Volume.MusicVolume, value);
        });
        _soundsVolumeSlider.onValueChanged.AddListener((value) =>
        {
            SetVolume(AudioManager.Volume.SoundsVolume, value);
        });
    }

    private void SetSliderValues()
    {
        if (_audioMixer.GetFloat(AudioManager.Volume.MasterVolume.ToString(), out float masterVolume))
        {
            _masterVolumeSlider.value = AudioManager.ConvertFromLogarithmic(masterVolume);
        }

        if (_audioMixer.GetFloat(AudioManager.Volume.MusicVolume.ToString(), out float musicVolume))
        {
            _musicVolumeSlider.value = AudioManager.ConvertFromLogarithmic(musicVolume);
        }

        if (_audioMixer.GetFloat(AudioManager.Volume.MusicVolume.ToString(), out float soundsVolume))
        {
            _soundsVolumeSlider.value = AudioManager.ConvertFromLogarithmic(soundsVolume);
        }
    }

    private void SaveSliderValues()
    {
        PlayerPrefs.SetFloat(AudioManager.Volume.MasterVolume.ToString(), _masterVolumeSlider.value);
        PlayerPrefs.SetFloat(AudioManager.Volume.MusicVolume.ToString(), _musicVolumeSlider.value);
        PlayerPrefs.SetFloat(AudioManager.Volume.SoundsVolume.ToString(), _soundsVolumeSlider.value);
    }

    private void SetVolume(AudioManager.Volume volume, float value)
    {
        _audioMixer.SetFloat(volume.ToString(), AudioManager.ConvertToLogarithmic(value));
    }
}
