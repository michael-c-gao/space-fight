using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{

    public bool activePower = false;
    public static bool triggerable = true;
    public static bool abilityActivated = false;

    public float count;
    public float startingDamage;
    public float playerDamage;
    public float powerupDamage;
    public static float attackpickup = 0;
    public static float maxCount = 50;

    public Image abilityBar;

    [SerializeField] ParticleSystem attackParticle;



    void LightAttack()
    {
        attackParticle.Play();
        if (triggerable)
        {
            count += 1;
        }
    }


    void HeavyAttack()
    {
        attackParticle.Play();
        if (triggerable)
        {
            count += 2;
        }
    }


    void Block()
    {
        if (triggerable)
        {
            count += 0.5f;
        }
    }


    void specialPower()
    {
        abilityActivated = true;
        count = 0;
        StartCoroutine(powerDuration());
        triggerable = true;

    }


    IEnumerator powerDuration()
    {
        activePower = true;
        playerDamage = powerupDamage;
        yield return new WaitForSeconds(5);
        abilityActivated = false;
        activePower = false;
    }


    void Update()
    {

        if (!GameOver.isGameOver && !Pause.isPaused) {
            if (!activePower)
            {
                playerDamage = startingDamage + attackpickup;
            }
            if (Input.GetMouseButtonDown(0)) {
                LightAttack();
            }

            if (Input.GetMouseButtonDown(1)) {
                HeavyAttack();
            }

            if (Input.GetKeyDown(KeyCode.Z)) {
                Block();
            }
        }
        
        if(count >= 50.0)
        {
            count = 50;
            triggerable = false;

            if (Input.GetKeyDown(KeyCode.X))
            {
                specialPower();
            }
        }

        abilityBar.fillAmount = (count / maxCount);

    }
}
