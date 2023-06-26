using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider))]
public class Teleport : MonoBehaviour, IInteractable
{
    public enum Scene
    {
        Room,
        Islands
    };

    [SerializeField]
    private Scene _destinationScene;

    public void Interact()
    {
        SceneManager.LoadScene(_destinationScene.ToString());
    }

    public Transform GetTransform()
    {
        return transform;
    }
}
