using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(DistanceJoint2D))]
public class DragableElement : MonoBehaviour
{
    public List<Transform> slots = new List<Transform>();
    bool isIn;
    bool inSlot;
    Transform cursor;
    Transform overSlot = null;

    Rigidbody2D cursorRb;
    Rigidbody2D rb;
    DistanceJoint2D distancejoint;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        distancejoint = GetComponent<DistanceJoint2D>(); distancejoint.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Cursor"))
        {
            cursorRb = other.GetComponent<Rigidbody2D>();
            cursor = other.transform;
            isIn = true;
            Debug.Log(other.name);
        }
        if (other.gameObject.TryGetComponent(out Slot TriggerSlot))
        {
            Debug.Log("Slot");
            foreach (Transform allowedSlot in slots)
            {
                if (TriggerSlot.transform == allowedSlot)
                {
                    Debug.Log("Found");
                    overSlot = allowedSlot;
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Cursor"))
        {
            isIn = false;
            Debug.Log(other.name);
        }

        if (other.gameObject.TryGetComponent(out Slot TriggerSlot))
        {
            foreach (Transform allowedSlot in slots)
            {
                if (TriggerSlot.transform == allowedSlot)
                {
                    overSlot = null;
                }
            }
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && isIn)
        {
            if (inSlot)
            {
                rb.isKinematic = false;
                rb.freezeRotation = false;
                inSlot = false;
            }
            Debug.Log("down");
            distancejoint.connectedBody = cursorRb;
            distancejoint.enabled = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (overSlot != null)
            {
                distancejoint.connectedBody = null;
                distancejoint.enabled = false;
                rb.isKinematic = true;
                rb.velocity = Vector2.zero;
                rb.freezeRotation = true;
                transform.position = overSlot.position;
                inSlot = true;
                overSlot.GetComponent<Slot>().OnSlotEvent.Invoke();
            }
            else
            {
                distancejoint.connectedBody = null;
                distancejoint.enabled = false;
                Debug.Log("up");
            }


        }
    }
}