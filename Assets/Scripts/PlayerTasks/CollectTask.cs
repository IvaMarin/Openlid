using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CollectTask : MonoBehaviour
{
    [SerializeField]
    private int _totalCount;

    private int _currentCount;

    [SerializeField]
    private GameObject _prefab;

    [SerializeField]
    private GameObject _player;

    private AudioSource _audioSource;

    [SerializeField]
    private AudioClip _completionSound;

    [Range(0, 1)]
    [SerializeField]
    private float _completionSoundVolume = 1f;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        GhostOrb.OnItemCollected += CountItems;
    }

    private void OnDisable()
    {
        GhostOrb.OnItemCollected -= CountItems;
    }

    private void CountItems()
    {
        _currentCount++;
        if (_currentCount == _totalCount)
        {
            GiveReward();
        }
    }

    void GiveReward()
    {
        _audioSource.PlayOneShot(_completionSound, _completionSoundVolume);
        _prefab.SetActive(true);
    }
}
