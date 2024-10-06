using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class MouseAwake : MonoBehaviour
{
    [SerializeField] private float _awakeDuration = 5f;
    [SerializeField] private UnityEvent eventAwake;
    private bool _awake = false;

    Vector3 _mousePos, _oldMousePos;

    float _movingTime = 0f;


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
            eventAwake.Invoke();
        }
        _oldMousePos = _mousePos;
    }
}
