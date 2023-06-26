using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider))]
public class Portal : MonoBehaviour, ICollectible
{
    private enum Scene
    {
        Room,
        Islands,
        City
    };

    [SerializeField]
    private Scene _destinationScene;

    public void Collect()
    {
        SceneManager.LoadScene(_destinationScene.ToString());
    }
}
