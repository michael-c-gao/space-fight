using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load : MonoBehaviour
{
    public GameObject[] array;
    // Start is called before the first frame update
    void Start()
    {
        array[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
