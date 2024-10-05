using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chatouille : MonoBehaviour
{
    public Sprite endormi;
    public Sprite eveille;

    private bool isIn;

    private void Start() 
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = endormi;
    }
    public void Chatouiller()
    {
            // if (Input.mouseScrollDelta>1 && isIn)
        //     {
        // gameObject.GetComponent<SpriteRenderer>().sprite = eveille;
        //     }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Cursor"))
        {
            isIn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Cursor"))
        {
            isIn = false;
        }
    }
}
