using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialAbility : MonoBehaviour
{
    public float maxAbility = 50;
    public float currAbility = 1.0f;
    public Image abilityBar;


    void Start()
    {
        currAbility = 1.0f;
        Shoot.count = 1;
        maxAbility = 50;
        abilityBar.fillAmount = (currAbility / maxAbility);
    }

    void ActiveAbility()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Shoot.count = 1;
            currAbility = 2;
            Debug.Log("ability active");
        }
    }

    void Update()
    {
        if(Shoot.count != currAbility && currAbility <= maxAbility)
        {
            currAbility = Shoot.count;
            abilityBar.fillAmount = (currAbility / maxAbility);
        }

        if(currAbility >= maxAbility)
        {
            Shoot.count = maxAbility;
            Debug.Log("ability can be activated");
            ActiveAbility();    

        }
    }

}
