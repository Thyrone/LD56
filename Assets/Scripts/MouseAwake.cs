using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAwake : MonoBehaviour
{
    [SerializeField] private float _awakeDuration = 5f;
    private bool _awake = false;

    Vector3 _mousePos, _oldMousePos;

    float _movingTime = 0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckMoving();
    }

    private void CheckMoving()
    {
        _mousePos = Input.mousePosition;

        float velocity = (_oldMousePos - _mousePos).sqrMagnitude;

        if (velocity >= 50f)
        {
            _movingTime += Time.deltaTime;
        }

        if (_movingTime >= _awakeDuration && !_awake)
        {
            _awake = true;
            Debug.Log("La souris est reveillé");
        }

        _oldMousePos = _mousePos;
    }
}
