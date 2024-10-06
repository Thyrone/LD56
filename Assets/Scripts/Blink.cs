using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    public float minBlink = 4, maxBlink = 10;
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(BlinkTime());
    }

    IEnumerator BlinkTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minBlink, maxBlink));
            animator.SetTrigger("Blink");
        }
    }
}
