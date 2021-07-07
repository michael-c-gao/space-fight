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
    public Vector3 movement;
    public bool sprintable = true;
    public bool subtractSecond = false;

    IEnumerator sprintRecharge()
    {
        subtractSecond = true;
  
        yield return new WaitForSeconds(2);

        sprintable = true;
        subtractSecond = false;
    }

    void Update()
    {
        if (!GameOver.isGameOver && !Pause.isPaused)
        {

            movementSpeed = startSpeed;
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 moveVector = (transform.right * horizontal) + (transform.forward * vertical);


            if (Input.GetKey(KeyCode.LeftShift) && sprintable)
            {

                movementSpeed = sprintSpeed;
                accumulatedSprintTime += Time.deltaTime;
                if(accumulatedSprintTime >= 3f)
                {
                    sprintable = false;
                }
            }

            if (!sprintable && !subtractSecond)
            {
                StartCoroutine(sprintRecharge());
                accumulatedSprintTime = 0;
                
            }
            
            movement = moveVector;
            CC.Move(moveVector * movementSpeed * Time.deltaTime);
        }
    }
}
