using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{

    public float startingHealth;
    public GameOver GameOver;

    public static float Health;
   
    void Start()
    {
        Health = startingHealth;
    }

   
    void FixedUpdate()
    {
        if(Health <= 0)
        {
            GameOver.Setup();
        }
    }
}
