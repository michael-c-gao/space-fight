using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class disableGameObject : MonoBehaviour
{

    public GameObject obj;

    void Start()
    {
        obj.SetActive(true);
    }


    void Update()
    {
        if (Pause.isPaused)
        {
            obj.SetActive(false);
        }
        else
        {
            if (!obj.activeSelf)
            {
                obj.SetActive(true);
            }
        }


    }
        
}

