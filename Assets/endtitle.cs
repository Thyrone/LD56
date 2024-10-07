using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class endtitle : MonoBehaviour
{
    public TMP_Text inputField;
    TMP_Text textFinal;
    // Start is called before the first frame update
    void Start()
    {
        textFinal = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inputField != null)
            textFinal.text = "Bienvenue \n dans \n" + inputField.text;
    }
}
