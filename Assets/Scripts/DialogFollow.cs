using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogFollow : MonoBehaviour
{
    [SerializeField] private GameObject _target;

    [SerializeField] private RectTransform _canvas;
    [SerializeField] private Camera _cam;

    private RectTransform _rect;

    private void Start()
    {
        TryGetComponent<RectTransform>(out _rect);
    }

    // Update is called once per frame
    void Update()
    {
        if (_target == null || _cam == null)
            return;

        //then you calculate the position of the UI element
        //0,0 for the canvas is at the center of the screen, whereas WorldToViewPortPoint treats the lower left corner as 0,0. Because of this, you need to subtract the height / width of the canvas * 0.5 to get the correct position.

        Vector2 ViewportPosition = _cam.WorldToViewportPoint(_target.transform.position);

        float offset = _rect.sizeDelta.x * 0.5f;
        offset = ViewportPosition.x <= 0.5f ? offset : -offset;
        Vector2 WorldObject_ScreenPosition = new Vector2(
        ((ViewportPosition.x * _canvas.sizeDelta.x) - (_canvas.sizeDelta.x * 0.5f) + offset),
        ((ViewportPosition.y * _canvas.sizeDelta.y) - (_canvas.sizeDelta.y * 0.5f)));

        //now you can set the position of the ui element
        _rect.anchoredPosition = WorldObject_ScreenPosition;
    }
}
