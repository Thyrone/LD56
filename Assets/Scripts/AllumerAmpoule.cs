using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class AllumerAmpoule : MonoBehaviour
{
    public Material eteint;
    public Material allume;
    public GameObject child;
    [SerializeField] private DialogueRunner _dialogueSystem;
    private bool dejaParle = false;

    private void Start() 
    {
        child.GetComponent<MeshRenderer>().material = eteint;
    }
    public void Allumer()
    {
        child.GetComponent<MeshRenderer>().material = allume;
       if(dejaParle == false)
       {
        StartDialogueAmpoule();
       } 
    }

    public void StartDialogueAmpoule()
    {
    _dialogueSystem.StartDialogue("Ampoule_001");
        DialogFollow.SetTarget(gameObject);
        dejaParle = true;
    }

}
