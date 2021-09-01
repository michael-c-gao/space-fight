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
    public GameObject[] abilityPowerups;
    private int arrayLen;
    private int abilityLen;

    void Start()
    {
        timeLeft = 100;
        arrayLen = powerups.Length;
        abilityLen = abilityPowerups.Length;
    }

    IEnumerator Countdown()
    {
        subtractSecond = true;
        timeLeft -= 1;
        yield return new WaitForSeconds(1);
        subtractSecond = false;
    }

    void Spawn(int modulo, GameObject[] array, int length)
    {
        if (timeLeft % modulo == 0)
        {
            for(int i = 0; i < length; i++)
            {
                if (!(array[i].activeSelf))
                {
                    array[i].SetActive(true);
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

        Spawn(20,powerups,arrayLen);
        Spawn(10, abilityPowerups, abilityLen) ;
        
        if (timeLeft == 0)
        {
            GameOver.Setup();
        }
    }

}
