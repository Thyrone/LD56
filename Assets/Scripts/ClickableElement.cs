using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class ClickableElement : MonoBehaviour
{
    public UnityEvent EventOnClick;
    bool isIn;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && isIn)
        {
            EventOnClick.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Cursor"))
        {
            isIn = true;
            // Debug.Log(other.name);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Cursor"))
        {
            isIn = false;
            // Debug.Log(other.name);
        }
    }
}
