using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

    public GameObject pausemenu;
    public static bool isPaused = false;
    
    void Start()
    {
        pausemenu.SetActive(false);
        
    }

    public void PauseGame()
    {
        pausemenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pausemenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void MainMenu()
    {
        pausemenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadScene("Menu");
    }

    public void Controls()
    {
        
    }




    public void QuitGame()
    {
        Application.Quit();
    }





    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (isPaused)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                ResumeGame();
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                PauseGame();
            }
        }
    }


}
