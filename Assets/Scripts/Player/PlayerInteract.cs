using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    private StarterAssetsInputs _input;

    [SerializeField]
    private float _interactionRadius = 2f;

    private void Start()
    {
        _input = GetComponent<StarterAssetsInputs>();
    }

    private void Update()
    {
        Interact();
    }

    private void Interact()
    {

        if (_input.interact)
        {
            IInteractable interactable = GetInteractableObject();
            if (interactable != null)
            {
                interactable.Interact();
            }
            _input.interact = false;
        }
    }

    public IInteractable GetInteractableObject()
    {
        List<IInteractable> interactableObjects = new();
        Collider[] colliders = Physics.OverlapSphere(transform.position, _interactionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent(out IInteractable interactable))
            {
                interactableObjects.Add(interactable);
            }
        }

        IInteractable closestInteractable = null;
        foreach (IInteractable interactable in interactableObjects)
        {
            if (closestInteractable == null)
            {
                closestInteractable = interactable;
            }
            else if (Vector3.Distance(transform.position, interactable.GetTransform().position) <
                     Vector3.Distance(transform.position, closestInteractable.GetTransform().position))
            {
                closestInteractable = interactable;
            }
        }

        return closestInteractable;
    }
}
