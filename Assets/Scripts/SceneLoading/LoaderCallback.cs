using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderCallback : MonoBehaviour
{
    private bool _isFirstCallback = true;


    private void Update()
    {
        if (_isFirstCallback)
        {
            _isFirstCallback = false;
            Loader.LoaderCallback();

        }
    }
}
