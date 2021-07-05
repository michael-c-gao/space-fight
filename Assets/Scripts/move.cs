using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public CharacterController CC;
    public float movementSpeed;
    public float startSpeed;
    public float sprintSpeed;
    public float timer = 0f;
    public float timer2 = 0f;
    public int timer3 = 0;
    public Vector3 movement;



    void Update()
    {

        movementSpeed = startSpeed;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        Vector3 moveVector = (transform.right * horizontal) + (transform.forward * vertical);


        if (Input.GetKey(KeyCode.LeftShift) && timer <= 3f){
            
            movementSpeed = sprintSpeed;
            timer += Time.deltaTime;
        }

        if (timer >= 2.9f)
        {
            timer2 += 1 * Time.deltaTime;
            timer3 = Mathf.RoundToInt(timer2);

            if(timer3 % 5 == 0 && timer3 != 0)
            {

                timer = 0; timer2 = 0; timer3 = 0;
            }
        }
        movement = moveVector;
            CC.Move(moveVector * movementSpeed * Time.deltaTime);
    }
}
