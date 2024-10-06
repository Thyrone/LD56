using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeToPoint : MonoBehaviour
{
    public AudioSource audioSource;
    public float maxVolume;

    SliderJoint2D sliderJoint2D;
    float maxSlider;
    // Start is called before the first frame update
    void Start()
    {
        sliderJoint2D = GetComponent<SliderJoint2D>();
        maxSlider = sliderJoint2D.limits.max;
        Debug.Log("maxSlider=" + maxSlider);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(sliderJoint2D.jointTranslation);
        Debug.Log(sliderJoint2D.jointTranslation);

        audioSource.volume = (1 - (sliderJoint2D.jointTranslation / maxSlider)) * maxVolume;
    }
}
