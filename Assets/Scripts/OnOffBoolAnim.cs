using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnOffBoolAnim : MonoBehaviour
{
    public UnityAction trueAction;
    public UnityAction falseAction;

    public Animator animator;
    public void TrueMethod(string animParam)
    {
        animator.SetBool(animParam, true);
        //trueAction.Invoke();
    }

    public void FalseMethod(string animParam)
    {
        animator.SetBool(animParam, false);
        //trueAction.Invoke();
    }

}
