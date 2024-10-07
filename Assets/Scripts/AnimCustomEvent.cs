using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimCustomEvent : MonoBehaviour
{
    public List<UnityEvent> unityEvents = new List<UnityEvent>();
    int step = 0;
    public void InvokeCustom(int i)
    {
        unityEvents[i].Invoke();
    }

    public void InvokeInSequance()
    {
        if (step < unityEvents.Count)
        {
            unityEvents[step].Invoke();
            step++;
        }


    }
}
