using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _theEnd;
    [SerializeField] private TMP_Text _thanks;
    [SerializeField] private TMP_Text _credits;
    [SerializeField] private TMP_Text _name;

    void Start()
    {
        StartCoroutine(ShowCredits());
    }

    private IEnumerator ShowCredits()
    {
        // Starting loading main scene:
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
        // But doesn't activate it yet:
        asyncLoad.allowSceneActivation = false;

        // Wait:
        yield return new WaitForSeconds(1f);

        // The END:
        float timer = 0f;
        float duration = 4f;
        while (timer <= duration)
        {
            float t = timer / duration;
            _theEnd.color = new Color(1f, 1f, 1f, t);
            timer += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        // Wait:
        yield return new WaitForSeconds(2f);
        // Fade out:
        timer = 0f;
        duration = 1f;
        while (timer <= duration)
        {
            float t = timer / duration;
            _theEnd.color = new Color(1f, 1f, 1f, 1f - t);
            timer += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        _theEnd.color = new Color(1f, 1f, 1f, 0f);

        // The Thanks for playing:
        timer = 0f;
        duration = 4f;
        while (timer <= duration)
        {
            float t = timer / duration;
            _thanks.color = new Color(1f, 1f, 1f, t);
            timer += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
        // Wait:
        yield return new WaitForSeconds(2f);
        // Fade out:
        timer = 0f;
        duration = 1f;
        while (timer <= duration)
        {
            timer += Time.deltaTime;
            float t = timer / duration;
            _thanks.color = new Color(1f, 1f, 1f, 1f - t);

            yield return new WaitForFixedUpdate();
        }
        _thanks.color = new Color(1f, 1f, 1f, 0f);

        // Credits:
        timer = 0f;
        duration = 4f;
        while (timer <= duration)
        {
            timer += Time.deltaTime;
            float t = timer / duration;
            _credits.color = new Color(1f, 1f, 1f, t);
            _name.color = new Color(1f, 1f, 1f, t);
            yield return new WaitForFixedUpdate();
        }
        // Wait:
        yield return new WaitForSeconds(4f);
        // Fade out:
        timer = 0f;
        duration = 1f;
        while (timer <= duration)
        {
            timer += Time.deltaTime;
            float t = timer / duration;
            _credits.color = new Color(1f, 1f, 1f, 1f - t);
            _name.color = new Color(1f, 1f, 1f, 1f - t);
            yield return new WaitForFixedUpdate();
        }
        _credits.color = new Color(1f, 1f, 1f, 0f);
        _name.color = new Color(1f, 1f, 1f, 0f);

        // SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
        asyncLoad.allowSceneActivation = true;
    }
}
