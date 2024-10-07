using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pompe : MonoBehaviour
{
    public UnityEvent actionDown;
    public UnityEvent actionUp;
    bool isIn;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && isIn)
        {
            actionDown.Invoke();
        }
        if (Input.GetMouseButtonUp(0) && isIn)
        {
            actionUp.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Cursor"))
        {
            isIn = true;
            Debug.Log(other.name);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Cursor"))
        {
            isIn = false;
            Debug.Log(other.name);
        }
    }
}
