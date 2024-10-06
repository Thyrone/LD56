using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn;
using Yarn.Unity;

public class ContinueDialog : MonoBehaviour
{

    [SerializeField] private DialogueRunner _dialogueSystem;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _dialogueSystem.Dialogue.Continue();
        }
    }
}