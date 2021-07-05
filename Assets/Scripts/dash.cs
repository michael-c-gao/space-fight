using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dash : MonoBehaviour
{
    move movementScript;
    public float dashSpeed;
    public float dashTime;
    public float cooldown;
    private float lastAttacked = -9999f;


    void Start()
    {
        movementScript = GetComponent<move>();
    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time > lastAttacked + cooldown)
            {
                StartCoroutine(Dash());
                lastAttacked = Time.time;
            }


        }


        IEnumerator Dash()
        {
            float starT = Time.time;

            while (Time.time < starT + dashTime)
            {
                movementScript.CC.Move(movementScript.movement * dashSpeed * Time.deltaTime);

                yield return null;
            }
        }
    }
}
