using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider))]
public class Slot : MonoBehaviour
{

    public UnityEvent OnSlotEvent;


}
