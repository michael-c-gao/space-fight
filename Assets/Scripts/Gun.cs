using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject[] weapons;
    private int currWeapon;
    public int minIndex = 0;
    public int maxIndex;


    void Start()
    {
        currWeapon = 0;
        weapons[currWeapon].SetActive(true);
        maxIndex = weapons.Length - 1;
    }

    void setWeapon(int index, int one, int setIndex) {

        weapons[currWeapon].SetActive(false);
        if (currWeapon != index)
        {
            currWeapon += one;
        }
        else
        {
            currWeapon = setIndex;
        }
        weapons[currWeapon].SetActive(true);

    }

    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            setWeapon(maxIndex, 1, 0);  
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            setWeapon(minIndex, -1, maxIndex); 
        }
     }
}
