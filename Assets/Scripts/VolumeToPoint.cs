using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VolumeToPoint : MonoBehaviour
{
    public AudioSource audioSource;
    public UnityEvent completeEvent;
    public float maxVolume;

    SliderJoint2D sliderJoint2D;
    float maxSlider;
    bool startCondition = false;
    // Start is called before the first frame update
    void Start()
    {
        sliderJoint2D = GetComponent<SliderJoint2D>();
        maxSlider = sliderJoint2D.limits.max;
        // Debug.Log("maxSlider=" + maxSlider);
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(sliderJoint2D.jointTranslation);
        // Debug.Log(sliderJoint2D.jointTranslation);

        audioSource.volume = (1 - (sliderJoint2D.jointTranslation / maxSlider)) * maxVolume;
        if (audioSource.volume > maxVolume - 0.03f && startCondition)
            completeEvent.Invoke();
    }

    IEnumerator waitBeforeStart()
    {
        yield return new WaitForSeconds(3f);
        startCondition = true;
    }
}
