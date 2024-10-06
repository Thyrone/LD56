using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinObj : MonoBehaviour
{
    bool isIn;
    Rigidbody2D cursorRb;
    Transform cursor;
    Vector3 screenPos;
    float angleOffset;
    // Start is called before the first frame update
    void Start()
    {

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
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Cursor"))
        {
            isIn = false;
            Debug.Log(other.name);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (isIn && Input.GetMouseButtonDown(0))
        {
            screenPos = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 vec3 = Input.mousePosition - screenPos;
            angleOffset = (Mathf.Atan2(transform.right.y, transform.right.x)
            - Mathf.Atan2(vec3.y, vec3.x)) * Mathf.Rad2Deg;
        }
        if (isIn && Input.GetMouseButton(0))
        {
            Vector3 vec3 = Input.mousePosition - screenPos;
            float angle = Mathf.Atan2(vec3.y, vec3.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, 0, angle + angleOffset);
        }
    }
}
