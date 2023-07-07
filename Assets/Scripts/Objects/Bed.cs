using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider))]
public class Bed : MonoBehaviour, IInteractable
{
    [SerializeField]
    private PauseMenu _pauseMenu;

    public void Interact()
    {
        _pauseMenu.dreamSelectionMenuUI.SetActive(true);
        _pauseMenu.Pause();
    }

    public Transform GetTransform()
    {
        return transform;
    }
}
