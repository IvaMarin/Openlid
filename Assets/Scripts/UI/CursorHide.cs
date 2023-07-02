using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorHide : MonoBehaviour
{
    [SerializeField]
    private bool _isHidden;

    private void Start()
    {
        if (_isHidden)
        {
            Cursor.visible = false;
        }
        else {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        
    }


}
