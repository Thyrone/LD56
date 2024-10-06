using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputKeyboardAction : MonoBehaviour
{
    public KeyCode keyCode;
    public UnityEvent action;

    private void Update()
    {
        if (Input.GetKeyDown(keyCode))
        {
            action.Invoke();
        }
    }
}
