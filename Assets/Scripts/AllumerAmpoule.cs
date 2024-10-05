using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllumerAmpoule : MonoBehaviour
{
    public Sprite eteint;
    public Sprite allume;

    private void Start() 
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = eteint;
    }
    public void Allumer()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = allume;
    }
}
