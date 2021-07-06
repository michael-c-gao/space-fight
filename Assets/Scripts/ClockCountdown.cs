using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClockCountdown : MonoBehaviour
{
    public TextMeshProUGUI clock;
    public static int timeLeft = 100;
    public bool subtractSecond = false;

    void Start()
    {
        timeLeft = 100;
    }

    IEnumerator Countdown()
    {
        subtractSecond = true;
        timeLeft -= 1;
        yield return new WaitForSeconds(1);
        subtractSecond = false;
    }

    void Update()
    {
        if (!subtractSecond)
        {
            StartCoroutine(Countdown());
            clock.text = "Time Remaining: " + (timeLeft);
        }
    }
}
