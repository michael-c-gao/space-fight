using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float enemyHealth = 100f;
    public GameOver GameOver;
    public float enemyMaxHealth = 100f;
    public Image enemybarhealth;



    public void BulletHit(float amount)
    {
        enemyHealth -= amount;
        print(enemyHealth);
        if(enemyHealth <= 0)
        {
            GameOver.Setup();
        }
    }

    void Update()
    {

       enemybarhealth.fillAmount = enemyHealth / enemyMaxHealth;
//
   }

}
