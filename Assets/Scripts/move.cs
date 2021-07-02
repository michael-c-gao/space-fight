using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public CharacterController CC;
    public float movementSpeed = 15f;

    void Update()
    { 
        movementSpeed = 15f;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveVector = (transform.right * horizontal) + (transform.forward * vertical);


        if (Input.GetKey(KeyCode.LeftShift)){
            movementSpeed = 35f;
        }



        CC.Move(moveVector * movementSpeed * Time.deltaTime);
    }
}
