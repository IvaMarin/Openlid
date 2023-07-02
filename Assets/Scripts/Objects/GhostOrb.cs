using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class GhostOrb : MonoBehaviour, ICollectible
{
    [SerializeField]
    private AudioClip _obtainSound;

    [Range(0, 1)]
    [SerializeField]
    private float _obtainSoundVolume = 1f;

    public static event Action OnItemCollected;

    public void Collect()
    {
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(_obtainSound, transform.position, _obtainSoundVolume);
        OnItemCollected?.Invoke();
    }
}
