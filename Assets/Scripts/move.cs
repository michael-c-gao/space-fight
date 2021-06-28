using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public CharacterController CC;
    public float movementSpeed = 5f;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveVector = (transform.right * horizontal) + (transform.forward * vertical);
        CC.Move(moveVector * movementSpeed * Time.deltaTime);
    }
}
