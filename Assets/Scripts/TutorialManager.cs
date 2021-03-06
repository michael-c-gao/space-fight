using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] tutorialArray;
    private int tutorialIndex = 0;
    private static bool pressedW = false;
    private static bool pressedA = false;
    private static bool pressedS = false;
    private static bool pressedD = false;


    void ShiftHold()
    {
        if (Input.GetKeyUp("left shift")){
            tutorialIndex += 1;
        }
    }

    void SpacePress()
    {
        if (Input.GetKeyUp(KeyCode.Space)){
            tutorialIndex += 1;
        }
    }

    void WASDPress()
    {
        if (Input.GetKey(KeyCode.W))
        {
            pressedW = true;
        }

        if (Input.GetKey(KeyCode.A))
        {
            pressedA = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            pressedS = true;
        }
         if (Input.GetKey(KeyCode.D))
        {
            pressedD = true;
        }
        if (pressedW && pressedA && pressedS && pressedD)
        {
            tutorialIndex += 1;
        }
    }

    void Update()
    {
        for (int i = 0; i < tutorialArray.Length; i++)
        {
            if (i == tutorialIndex)
            {
                tutorialArray[i].SetActive(true);
            }
            else
            {
                tutorialArray[i].SetActive(false);
            }
            if (Pause.isPaused)
            {
                tutorialArray[i].SetActive(false);
            }
        }

        if (tutorialIndex == 2) {
            WASDPress();
        }
        else if (tutorialIndex == 5)
        {
            ShiftHold();
        }
        else if (tutorialIndex == 6)
        {
            SpacePress();
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                tutorialIndex += 1;
            }
        }
    }

}
