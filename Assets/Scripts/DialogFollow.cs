using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn;
using Yarn.Unity;

public class DialogFollow : MonoBehaviour
{
    [SerializeField] private GameObject _target;

    [SerializeField] private RectTransform _canvas;
    [SerializeField] private Camera _cam;
    [SerializeField] private DialogueRunner _dialogRunner;
    [SerializeField] private float _ui_offset = 0f;

    private RectTransform _rect;

    private static DialogFollow _instance;

    private void Start()
    {
        _instance = this;
        TryGetComponent<RectTransform>(out _rect);
    }

    // Update is called once per frame
    void Update()
    {
        if (_target == null || _cam == null)
            return;

        Vector2 ViewportPosition = _cam.WorldToViewportPoint(_target.transform.position);

        float offset = _rect.sizeDelta.x * 0.5f + _ui_offset;
        offset = ViewportPosition.x <= 0.5f ? offset : -offset;
        Vector2 WorldObject_ScreenPosition = new Vector2(
        ((ViewportPosition.x * _canvas.sizeDelta.x) - (_canvas.sizeDelta.x * 0.5f) + offset),
        ((ViewportPosition.y * _canvas.sizeDelta.y) - (_canvas.sizeDelta.y * 0.5f)));

        //now you can set the position of the ui element
        _rect.anchoredPosition = WorldObject_ScreenPosition;
    }

    public static void SetTarget(GameObject target)
    {
        if (_instance)
            _instance._target = target;
    }

    public static void CloseDialogue()
    {
        if (_instance)
            _instance._dialogRunner.Stop();
    }
}
