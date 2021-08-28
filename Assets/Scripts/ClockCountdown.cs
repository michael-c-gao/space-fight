using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClockCountdown : MonoBehaviour
{
    public GameOver GameOver;
    public TextMeshProUGUI clock;
    public bool subtractSecond = false;
    public static int timeLeft = 100;
    public GameObject[] powerups;
    public int arrayLen;

    void Start()
    {
        timeLeft = 100;
        arrayLen = powerups.Length;
    }

    IEnumerator Countdown()
    {
        subtractSecond = true;
        timeLeft -= 1;
        yield return new WaitForSeconds(1);
        subtractSecond = false;
    }

    void Spawn()
    {
        if (timeLeft == 60 || timeLeft == 30)
        {
            for(int i = 0; i < arrayLen; i++)
            {
                if (!(powerups[i].activeSelf))
                {
                    powerups[i].SetActive(true);
                }
            }
        }
    }

    void Update()
    {
        if (!subtractSecond)
        {
            StartCoroutine(Countdown());
            clock.text = "Time Remaining: " + (timeLeft);
        }
        if(timeLeft == 0)
        {
            GameOver.Setup();
        }

        Spawn();
    }
}
