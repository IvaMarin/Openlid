using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class GameCompletion : MonoBehaviour
{
    public static bool hasCompletedIslands;
    public static bool hasCompletedCity;


    public static bool hasKeyToCabin;
    private void OnEnable()
    {
        Portal.OnLocationCompleted += OnLocationCompleted;
    }

    private void OnDisable()
    {
        Portal.OnLocationCompleted -= OnLocationCompleted;
    }

    private void OnLocationCompleted(Loader.Scene finishedLocation)
    {
        switch (finishedLocation)
        {
            case Loader.Scene.Islands:
                hasCompletedIslands = true;
                break;
            case Loader.Scene.City:
                hasCompletedCity = true;
                break;
        }
    }
}
