using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadCharacter : MonoBehaviour
{
    public GameObject[] characterLoad;


    void Start()
    {
        int character = PlayerPrefs.GetInt("character");
        characterLoad[character].SetActive(true);
    }

    
}
