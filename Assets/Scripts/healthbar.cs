using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour
{
    public Image barhealth;
    public float playerCurrHealth;

    void Start()
    {
        playerCurrHealth = PlayerStats.healthmax;
    }


    void Update()
    {
        if (PlayerStats.Health != playerCurrHealth)
        {
            playerCurrHealth = PlayerStats.Health;
            barhealth.fillAmount = playerCurrHealth / PlayerStats.healthmax;
        }
        
    }
}
