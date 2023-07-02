using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Key : MonoBehaviour, ICollectible
{
    [SerializeField]
    private AudioClip _obtainSound;

    [Range(0, 1)]
    [SerializeField]
    private float _obtainSoundVolume = 1f;

    public void Collect()
    {
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(_obtainSound, transform.position, _obtainSoundVolume);
        GameCompletion.hasKeyToCabin = true;
    }
}
