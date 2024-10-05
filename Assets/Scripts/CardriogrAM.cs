using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CardriogrAM : MonoBehaviour
{
    [SerializeField] private int _nbSuccess = 3;
    private int _currentSuccess = 0;
    private bool _playerTried = false;
    [SerializeField] private float _duration = 1f;
    [SerializeField] private SpriteRenderer _renderer;

    [SerializeField] private Color _baseColor = new Color(0.2745099f, 0.6266922f, 0.8f, 1f);
    [SerializeField] private Color _errorColor;
    [SerializeField] private Color _successColor;

    private float _timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _renderer.material.SetFloat("_CardioTime", _timer / _duration);

        if (!_playerTried && Input.GetKeyDown(KeyCode.Space))
        {
            _playerTried = true;
            if (_timer >= 0.25f && _timer < 0.75f)
            {
                _currentSuccess++;
                StartCoroutine(ChangeColor(_successColor));
                Debug.Log("Succès " + _currentSuccess + " / " + _nbSuccess);
            }
            else
            {
                _currentSuccess = 0;
                StartCoroutine(ChangeColor(_errorColor));
                Debug.Log("Fail -> Reset 0 / 0");
            }
        }

        _timer += Time.deltaTime;

        if (_timer > 1f)
        {
            _timer = 0f;
            _playerTried = false;
        }
    }

    private IEnumerator ChangeColor(Color color)
    {
        float timer = 0f;
        float duration = 0.25f;
        while (timer <= duration)
        {
            float t = timer / duration;
            _renderer.material.SetColor("_Color", Color.Lerp(_baseColor, color, t));
            timer += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        yield return new WaitForSeconds(0.5f);

        timer = 0f;
        while (timer <= duration)
        {
            float t = timer / duration;
            _renderer.material.SetColor("_Color", Color.Lerp(color, _baseColor, t));
            timer += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }

    }
}
