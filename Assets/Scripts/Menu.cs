using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PvE()
    {
        SceneManager.LoadScene("CharacterSelect");
    }

    public void PvP()
    {
        SceneManager.LoadScene("OnlineLevelSelect");
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("TutorialLevel");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void returnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
