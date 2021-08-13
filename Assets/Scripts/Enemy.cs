using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public float enemyHealth = 100f;
    public GameOver GameOver;


    public void BulletHit(float amount)
    {
        enemyHealth -= amount;
        if(enemyHealth <= 0)
        {
            GameOver.Setup();
        }
    }

}
