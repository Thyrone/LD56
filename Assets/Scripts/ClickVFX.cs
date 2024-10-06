using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickVFX : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform _canvas;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 vector3 = Input.mousePosition;
            Quaternion rot = Quaternion.Euler(0, 0, Random.Range(0, 360f));
            Instantiate(prefab, vector3, rot, _canvas);
        }
    }
}
