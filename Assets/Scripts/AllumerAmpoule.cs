using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllumerAmpoule : MonoBehaviour
{
    public Material eteint;
    public Material allume;
    public GameObject child;

    private void Start() 
    {
        child.GetComponent<MeshRenderer>().material = eteint;
    }
    public void Allumer()
    {
        child.GetComponent<MeshRenderer>().material = allume;
    }
}
