using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardriogrAM : MonoBehaviour
{
    [SerializeField] private int _nbSuccess = 3;
    private int _currentSuccess = 0;
    [SerializeField] private float _duration = 1f;
    [SerializeField] private SpriteRenderer _renderer;

    private float _timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _renderer.material.SetFloat("_CardioTime", _timer / _duration);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_timer >= 0.25f && _timer < 0.75f)
            {
                _currentSuccess++;
                Debug.Log("Succès " + _currentSuccess + " / " + _nbSuccess);
            }
            else
            {
                _currentSuccess = 0;
                Debug.Log("Fail -> Reset 0 / 0");
            }
        }

        _timer += Time.deltaTime;
        _timer = _timer <= 1f ? _timer : 0f;
    }
}
