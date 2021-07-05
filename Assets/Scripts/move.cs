using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public CharacterController CC;
    public float movementSpeed;
    public float startSpeed;
    public float sprintSpeed;
    public float accumulatedSprintTime = 0f;
    public float sprintRecharge = 0f;
    public int intSprintRecharge = 0;
    public Vector3 movement;



    void Update()
    {

        movementSpeed = startSpeed;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        Vector3 moveVector = (transform.right * horizontal) + (transform.forward * vertical);


        if (Input.GetKey(KeyCode.LeftShift) && accumulatedSprintTime <= 3f){
            
            movementSpeed = sprintSpeed;
            accumulatedSprintTime += Time.deltaTime;
        }

        if (accumulatedSprintTime >= 2.9f)
        {
            sprintRecharge += 1 * Time.deltaTime;
            intSprintRecharge = Mathf.RoundToInt(sprintRecharge);

            if(intSprintRecharge % 5 == 0 && intSprintRecharge != 0)
            {

                accumulatedSprintTime = 0; 
                sprintRecharge = 0; 
                intSprintRecharge = 0;
            }
        }

        movement = moveVector;
        CC.Move(moveVector * movementSpeed * Time.deltaTime);
    }
}
