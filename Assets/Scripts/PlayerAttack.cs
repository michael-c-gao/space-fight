using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    public float count;
    public static float maxCount = 50;
    public static bool triggerable = true;
    public Image abilityBar;



    void Punch()
    {
        print("Punch");
        if (triggerable)
        {
            count += 1;
        }
    }


    void Kick()
    {
        print("Kick");
        if (triggerable)
        {
            count += 2;
        }
    }


    void Block()
    {
        print("Block");
        if (triggerable)
        {
            count += 0.5f;
        }
    }


    void specialPower()
    {
        print("special power activated");
        count = 0;
        triggerable = true;

    }


    void Update()
    {

        if (!GameOver.isGameOver && !Pause.isPaused) {
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
        print(count);

    }
}
