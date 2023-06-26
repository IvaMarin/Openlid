using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectTask : MonoBehaviour
{
    [SerializeField]
    private int _totalCount;

    private int _currentCount;

    [SerializeField]
    private GameObject _prefab;

    [SerializeField]
    private GameObject _player;

    [SerializeField]
    private AudioClip _completionSound;

    [Range(0, 1)]
    [SerializeField]
    private float _completionSoundVolume = 1f;

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
        print(_currentCount);
        if (_currentCount == _totalCount)
        {
            GiveReward();
        }
    }

    void GiveReward()
    {
        print("all orbs collected");
        AudioSource.PlayClipAtPoint(_completionSound, _player.transform.position, _completionSoundVolume);
        _prefab.SetActive(true);
    }
}
