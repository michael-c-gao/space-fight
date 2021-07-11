using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class move : MonoBehaviour
{
    public CharacterController CC;
    public float movementSpeed;
    public float startSpeed;
    public float boostSpeed;
    public float accumulatedBoostTime = 0f;
    public Vector3 movement;
    public bool boostable = true;
    public bool subtractSecond = false; 
    public Image boostBar;
    public float boostMax = 3;
    [SerializeField] ParticleSystem boostParticle;
    [SerializeField] ParticleSystem defaultParticle;



    IEnumerator boostRecharge()
    {
        subtractSecond = true;
  
        yield return new WaitForSeconds(2);

        boostable = true;
        subtractSecond = false;
        boostBar.fillAmount = 1;
    }


    void Update()
    {
        if (!GameOver.isGameOver && !Pause.isPaused)
        {
            
            movementSpeed = startSpeed;
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 moveVector = (transform.right * horizontal) + (transform.forward * vertical);


            if (Input.GetKey(KeyCode.LeftShift) && boostable)
            {

                defaultParticle.Stop();
                boostParticle.Play();

                movementSpeed = boostSpeed;

                accumulatedBoostTime += Time.deltaTime;

                boostBar.fillAmount = ((boostMax - accumulatedBoostTime) / 3);

                if (accumulatedBoostTime >= 3f)
                {
                    boostable = false;
                }
            } 
            else {

                defaultParticle.Play();
                boostParticle.Stop();
            }

            
            if (!boostable && !subtractSecond)
            {
                StartCoroutine(boostRecharge());
                accumulatedBoostTime = 0;
                
                
            }
            
            movement = moveVector;
            CC.Move(moveVector * movementSpeed * Time.deltaTime);
        }
    }
}
