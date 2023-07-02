using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider))]
public class Portal : MonoBehaviour, ICollectible
{
    [SerializeField]
    private Loader.Scene _currentScene;

    [SerializeField]
    private Loader.Scene _destinationScene;

    public static Action<Loader.Scene> OnLocationCompleted;

    public void Collect()
    {
        OnLocationCompleted?.Invoke(_currentScene);
        Loader.Load(_destinationScene);
    }
}
