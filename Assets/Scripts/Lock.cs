using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour, IInteractable
{
    [SerializeField]
    private Collector _collector;
    [SerializeField]
    private Door _door;

    public void Interact()
    {
        if (_collector.hasKeyToCabin)
        {
            gameObject.SetActive(false);
            _door.isLocked = false;
        }
    }

    public Transform GetTransform()
    {
        return transform;
    }
}
