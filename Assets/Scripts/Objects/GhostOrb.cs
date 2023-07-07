using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Collider))]
public class GhostOrb : MonoBehaviour, ICollectible
{
    private AudioSource _audioSource;

    public static event Action OnItemCollected;

    private void Awake()
    {
        _audioSource = gameObject.transform.parent.gameObject.GetComponent<AudioSource>();
    }

    public void Collect()
    {
        Destroy(gameObject);
        _audioSource.Play();
        OnItemCollected?.Invoke();
    }
}
