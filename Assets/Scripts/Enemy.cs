using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float enemyCurrHealth;
    public float enemyHealth = 100f;
    public float enemyMaxHealth = 100f;
    public GameOver GameOver;
    public Image enemybarhealth;

    void Start()
    {
        enemyCurrHealth = enemyMaxHealth;
    }

    public void BulletHit(float amount)
    {
        enemyHealth -= amount;

        if (enemyHealth <= 0)
        {
            GameOver.Setup();
        }
    }

    void Update()
    {
        if (enemyCurrHealth != enemyHealth)
        {
            enemybarhealth.fillAmount = enemyHealth / enemyMaxHealth;
            enemyCurrHealth = enemyHealth;
        }
    }
}
