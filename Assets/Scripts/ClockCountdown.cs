using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClockCountdown : MonoBehaviour
{
    public TextMeshProUGUI clock;
    public static int timeLeft = 100;


    void Start()
    {
        timeLeft = 100;
    }

    void Update()
    {
        clock.text = "Time Remaining: " + (timeLeft - Mathf.Floor(Time.time));
    }
}
