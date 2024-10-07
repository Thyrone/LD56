using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn;
using Yarn.Unity;

public class DialogueTimed : MonoBehaviour
{
    public string dialogName;
    public GameObject ampoule;
    public float time;

    DialogueRunner dialogueRunner;

    private void Start()
    {
        dialogueRunner = FindFirstObjectByType<DialogueRunner>();
        StartCoroutine(delayDialog());
    }
    IEnumerator delayDialog()
    {
        yield return new WaitForSeconds(time);
        DialogFollow.CloseDialogue();
        DialogFollow.SetTarget(ampoule);
        dialogueRunner.StartDialogue(dialogName);
    }
}
