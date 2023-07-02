using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider))]
public class Teleport : MonoBehaviour, IInteractable
{
    [SerializeField]
    private Loader.Scene _destinationScene;

    public void Interact()
    {
        Loader.Load(_destinationScene);
    }

    public Transform GetTransform()
    {
        return transform;
    }
}
