using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class OpenTheDoors : MonoBehaviour
{
    [SerializeField] private RectTransform _rightDoor;
    [SerializeField] private RectTransform _leftDoor;

    [SerializeField] private RectTransform _door00;
    [SerializeField] private RectTransform _door01;
    [SerializeField] private RectTransform _door02;
    [SerializeField] private RectTransform _door03;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(OpenTheGate());
            StartCoroutine(OpenDoor(_door00, 0.2f));
            StartCoroutine(OpenDoor(_door01, 0.4f));
            StartCoroutine(OpenDoor(_door02, 0.6f));
            StartCoroutine(OpenDoor(_door03, 0.8f));
        }
    }

    private IEnumerator OpenDoor(RectTransform door, float delay)
    {
        yield return new WaitForSeconds(delay);
        float timer = 0f;
        float duration = 400f;
        float elapsedTime = 0f;
        while (timer <= duration)
        {
            float t = timer / duration;
            if (elapsedTime >= 0.08333f)
            {
                door.transform.position += elapsedTime * Vector3.up * 60f;
                elapsedTime = 0f;
            }

            elapsedTime += Time.deltaTime;
            timer += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
    }

    private IEnumerator OpenTheGate()
    {
        float timer = 0f;
        float duration = 400f;
        float elapsedTime = 0f;
        while (timer <= duration)
        {
            float t = timer / duration;
            if (elapsedTime >= 0.08333f)
            {
                _rightDoor.transform.position += elapsedTime * Vector3.right * 80f;
                _leftDoor.transform.position += elapsedTime * -Vector3.right * 80f;
                elapsedTime = 0f;
            }

            elapsedTime += Time.deltaTime;
            timer += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
    }
}
