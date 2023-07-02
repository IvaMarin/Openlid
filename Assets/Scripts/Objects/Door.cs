using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
public class Door : MonoBehaviour, IInteractable
{
    private Animator _animator;
    private bool _isClosed = true;

    public bool isLocked = false;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Interact()
    {
        if (isLocked)
        {
            return;
        }

        if (_isClosed)
        {
            _animator.ResetTrigger("Close");
            _animator.SetTrigger("Open");
            _isClosed = false;
        }
        else
        {
            _animator.ResetTrigger("Open");
            _animator.SetTrigger("Close");
            _isClosed = true;
        }
    }

    public Transform GetTransform()
    {
        return transform;
    }
}
