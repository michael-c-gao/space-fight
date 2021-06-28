using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Arena");
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("Arena");
    }

    public void Quit()
    {
        Application.Quit();
    }


   

}
