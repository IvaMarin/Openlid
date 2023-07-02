using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioMixer _audioMixer;

    public static AudioManager instance;

    public enum Volume
    {
        MasterVolume,
        MusicVolume,
        SoundsVolume
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        LoadVolume();
    }

    private void LoadVolume()
    {
        float masterVolume = PlayerPrefs.GetFloat(Volume.MasterVolume.ToString(), 1f);
        _audioMixer.SetFloat(Volume.MasterVolume.ToString(), ConvertToLogarithmic(masterVolume));

        float musicVolume = PlayerPrefs.GetFloat(Volume.MusicVolume.ToString(), 1f);
        _audioMixer.SetFloat(Volume.MusicVolume.ToString(), ConvertToLogarithmic(musicVolume));

        float soundsVolume = PlayerPrefs.GetFloat(Volume.SoundsVolume.ToString(), 1f);
        _audioMixer.SetFloat(Volume.SoundsVolume.ToString(), ConvertToLogarithmic(soundsVolume));
    }

    public static float ConvertToLogarithmic(float value)
    {
        return Mathf.Log10(value) * 20;
    }

    public static float ConvertFromLogarithmic(float value)
    {
        return Mathf.Pow(10, value / 20);
    }

}
