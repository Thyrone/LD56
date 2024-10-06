using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapSoundSlider : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _sliderRB;
    [SerializeField] private Rigidbody2D _handleRB;

    public void OnSliderSet()
    {
        _sliderRB.bodyType = RigidbodyType2D.Kinematic;
        _sliderRB.GetComponent<DragableElement>().enabled = false;

        // _handleRB.bodyType = RigidbodyType2D.Kinematic;
        // _handleRB.simulated = false;
        _handleRB.GetComponent<SliderJoint2D>().enabled = false;
    }
}
