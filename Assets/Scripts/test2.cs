using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class test2 : MonoBehaviour
{
    public GameObject[] buttonArray;
    public GameObject[] PlayerArray;
    public GameObject resetButton;
    public GameObject playButton;
    public GameObject empty;
    public int characterSelect = 0;
    public bool Reset = false;
    public GameObject[] bewl;


    public int RIndex = 0;
    public int GIndex = 1;
    public int BIndex = 2;


    void Start()
    {
        resetButton.SetActive(false);
        playButton.SetActive(false);

        bewl[0] = empty;
    }

    public void returnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }



    public void RClick()
    {
        int x = buttonArray.Length;
        for (int i = 0; i < x; i++)
        {
            if(i == 0)
            {
                bewl[0] = PlayerArray[i];
            }
            else
            {
                buttonArray[i].SetActive(false);
            }
        }
        resetButton.SetActive(true);
        playButton.SetActive(true);
        characterSelect = 0;
    }

    public void GClick()
    {
        int x = buttonArray.Length;
        for (int i = 0; i < x; i++)
        {
            if (i == 1)
            {
                bewl[0] = PlayerArray[i];
            }
            else
            {
                buttonArray[i].SetActive(false);
            }
        }
        resetButton.SetActive(true);
        playButton.SetActive(true);
        characterSelect = 1;
    }

    public void BClick()
    {
        int x = buttonArray.Length;
        for (int i = 0; i < x; i++)
        {
            if (i == 2)
            {
                bewl[0] = PlayerArray[i];
            }
            else
            {
                buttonArray[i].SetActive(false);
            }
        }
        resetButton.SetActive(true);
        playButton.SetActive(true);
        characterSelect = 2;
    }

    public void resetButtons()
    {
        int x = buttonArray.Length;
        for (int i = 0; i < x; i++)
        {
            buttonArray[i].SetActive(true);
        }
        resetButton.SetActive(false);
        playButton.SetActive(false);
        bewl[0] = empty;
    }


    public void startGame()
    {
        PlayerPrefs.SetInt("character", characterSelect);
        SceneManager.LoadScene("Arena");
    }
}
