using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class disableImage : MonoBehaviour
{
    public Image element;

    void Update()
    {
        if (Pause.isPaused)
        {
            element.enabled = false;
        }else{
            element.enabled = true;
        }
    }
}
