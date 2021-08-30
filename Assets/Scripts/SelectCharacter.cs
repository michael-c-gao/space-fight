using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectCharacter : MonoBehaviour
{
    public GameObject[] playerText;
    public GameObject playButton;
    public int characterSelect;
    int prev = -999;


    void returnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    void setPlayer()
    {
        if (prev != -999)
        {
            playerText[prev].SetActive(false);
        }
        prev = characterSelect;
        playerText[characterSelect].SetActive(true);
        playButton.SetActive(true);
    }

    void RClick()
    {
        characterSelect = 0;
        setPlayer();
    }

    void GClick()
    {
        characterSelect = 1;
        setPlayer();
    }

    void BClick()
    {
        characterSelect = 2;
        setPlayer();
    }
    
    void startGame()
    {
        PlayerPrefs.SetInt("character", characterSelect);
        SceneManager.LoadScene("Arena");
    }

}
