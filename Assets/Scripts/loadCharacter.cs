using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadCharacter : MonoBehaviour
{
    public GameObject[] characterLoad;
    public static int character;

    void Start()
    {
        ClockCountdown.timeLeft = 100;
        character = PlayerPrefs.GetInt("character");
        characterLoad[character].SetActive(true);
    }
}
