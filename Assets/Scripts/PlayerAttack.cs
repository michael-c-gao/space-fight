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
    public static float maxCount = 50;

    public Image abilityBar;

    [SerializeField] ParticleSystem attackParticle;



    void Punch()
    {
        attackParticle.Play();
        if (triggerable)
        {
            count += 1;
        }
    }


    void Kick()
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
                playerDamage = startingDamage;
            }
            if (Input.GetKeyDown(KeyCode.Q)) {
                Punch();
            }

            if (Input.GetKeyDown(KeyCode.E)) {
                Kick();
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
