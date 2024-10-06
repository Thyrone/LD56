using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickVFXAutoDestroy : MonoBehaviour
{
    [SerializeField] private float _timeBeforeAutoDestroy  = 0.25f;
    void Start()
    {
        Destroy(gameObject, _timeBeforeAutoDestroy);   
    }
}
