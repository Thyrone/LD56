using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{


    AsyncOperation asyncLoad;

    public void PreLoadScene(string scene)
    {
        asyncLoad = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Single);
        asyncLoad.allowSceneActivation = false;
    }

    public void LoadCustomScene()
    {
        StartCoroutine(delay());
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(2f); asyncLoad.allowSceneActivation = true;
    }

}
