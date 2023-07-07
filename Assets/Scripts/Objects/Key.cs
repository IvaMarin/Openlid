using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Key : MonoBehaviour, ICollectible
{
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = transform.parent.gameObject.GetComponent<AudioSource>();
    }

    public void Collect()
    {
        Destroy(gameObject);
        _audioSource.Play();
        GameCompletion.hasKeyToCabin = true;
    }
}
