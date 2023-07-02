using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Water : MonoBehaviour, ICollectible
{
    [SerializeField]
    private Loader.Scene _activeScene;
    public void Collect() {
        Loader.Load(_activeScene);
    }
}
