using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{

    public GameObject[] tutorialArray;
    private int tutorialIndex = 0;

    void Update()
    {
        for(int i = 0; i < tutorialArray.Length; i++)
        {
            if (i == tutorialIndex)
            {
                tutorialArray[i].SetActive(true);
            }else{
                tutorialArray[i].SetActive(false);
            }   
        }   
        if(tutorialIndex >= 0)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                tutorialIndex += 1;
            }
        }
    }
}
