using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Chatouille : MonoBehaviour
{
    [Serializable]
    public struct ChatouilleCoef
    {
        public int value;
        public UnityEvent ChatouilleEvent;
    }
    public List<ChatouilleCoef> ChatouilleCoefs = new List<ChatouilleCoef>();
    private bool isIn;

    private float valueScroll = 0f;

    public void Chatouiller()
    {
        if (Input.mouseScrollDelta.y > 1 || Input.mouseScrollDelta.y < -1 && isIn)
        {
            valueScroll += 1f;
            foreach (ChatouilleCoef coef in ChatouilleCoefs)
            {
                Debug.Log("coef=" + coef.value + " / ValueScroll=" + valueScroll);
                if (coef.value == valueScroll)
                {
                    coef.ChatouilleEvent.Invoke();
                }
            }
        }
    }

    private void Update()
    {
        Chatouiller();
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
