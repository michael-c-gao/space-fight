using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour
{
    private Image barhealth;
    //public float maxhealth;


    void Start()
    {
        barhealth = GetComponent<Image>();

    }

     void Update()
    {
        
        barhealth.fillAmount = PlayerStats.Health / PlayerStats.healthmax;
        
    }
}
