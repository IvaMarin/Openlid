using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomChanges : MonoBehaviour
{
    [SerializeField]
    private GameObject _islandsTrophy;

    [SerializeField]
    private GameObject _cityTrophy;

    [SerializeField]
    private GameObject _portal;

    [SerializeField]
    private Door _door;

    private void Start()
    {

        if (GameCompletion.hasCompletedIslands)
        {
            _islandsTrophy.SetActive(true);
        }

        if (GameCompletion.hasCompletedCity)
        {
            _cityTrophy.SetActive(true);
        }

        if (GameCompletion.hasCompletedIslands && GameCompletion.hasCompletedCity)
        {
            _portal.SetActive(true);
            _door.isLocked = false;
        }
    }
}
