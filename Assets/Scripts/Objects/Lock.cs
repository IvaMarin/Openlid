using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour, IInteractable
{
    [SerializeField]
    private Door _door;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = gameObject.transform.parent.gameObject.GetComponent<AudioSource>();
    }

    public void Interact()
    {
        if (GameCompletion.hasKeyToCabin)
        {
            _audioSource.Play();
            gameObject.SetActive(false);
            _door.isLocked = false;
        }
    }

    public Transform GetTransform()
    {
        return transform;
    }
}
