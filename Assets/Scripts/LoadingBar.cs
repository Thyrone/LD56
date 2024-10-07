using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingBar : MonoBehaviour
{
    private Animator _animator;

    private bool _isYeaying = false;

    private Vector2 _blinkEvery = new Vector2(4f, 10f);
    private float _timer = 0f;
    private float _nextBlink = 0f;

    void Start()
    {
        _animator = GetComponent<Animator>();

        _nextBlink = Random.Range(_blinkEvery.x, _blinkEvery.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Yeah();
        }


        if (_timer >= _nextBlink)
        {
            Blink();
        }

        _timer += Time.deltaTime;
    }

    private void Blink()
    {
        _nextBlink = Random.Range(_blinkEvery.x, _blinkEvery.y);
        Debug.Log("Next Blink in " + _nextBlink);
        _timer = 0f;
        if (!_isYeaying)
        {
            _animator.SetTrigger("blink");
        }
    }

    public void Yeah()
    {
        _isYeaying = true;
        _animator.SetTrigger("yeah");
        StartCoroutine(ResetYeaying());
    }

    private IEnumerator ResetYeaying()
    {
        yield return new WaitForSeconds(1f);
        _isYeaying = false;
    }
}
