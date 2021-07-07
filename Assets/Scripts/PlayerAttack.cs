using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
 
    void Punch()
    {
        print("Punch");
    }

    void Kick()
    {
        print("Kick");
    }

    void Block()
    {
        print("Block");
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


    }
}
