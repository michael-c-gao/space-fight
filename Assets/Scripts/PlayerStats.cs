using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStats : MonoBehaviour
{
    public float startingHealth;
    public float maxHealth;
    public static float healthmax;
    public GameOver GameOver;

    public static float Health;
   
    void Start()
    {
        healthmax = maxHealth;
        Health = startingHealth;
    }

    void FixedUpdate()
    {
        if(Health > maxHealth)
        {
            Health = maxHealth;
        }

        if (Health <= 0)
        {
            GameOver.Setup();
        }
    }

}
