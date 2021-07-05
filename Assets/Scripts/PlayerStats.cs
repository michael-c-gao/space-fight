using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{

    //public TextMeshProUGUI health;
    public float startingHealth;

    public static float Health;
   
    void Start()
    {
        Health = startingHealth;
    }

   
    void FixedUpdate()
    {
        //health.text = "Health: " + Health;
    }
}
