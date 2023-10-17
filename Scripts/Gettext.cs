using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Gettext : MonoBehaviour
{
    public static string ResultText = "";
    //public TextMeshProUGUI test;


public static void SetText(string res)
{
    ResultText = res;
    
}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = ResultText;
        //test.text = str;
        //gameObject.GetComponent<TextMeshPro>().text = String.Copy(ResultText);
    }

    public void DwellProcess()
    {
        Debug.Log("Dwell");
    }
}
