using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class disableText : MonoBehaviour
{

    public GameObject g;


    void Update()
    {
        if (Pause.isPaused)
        {
            g.SetActive(false);
        }
        else
        {
            g.SetActive(true);
        }


    }
        
}

