using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load : MonoBehaviour
{
    public GameObject[] array;

    void Start()
    {
        array[0].SetActive(true);
    }

}
