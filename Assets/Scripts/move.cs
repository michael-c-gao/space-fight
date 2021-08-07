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
    public float boostMax = 3;
    public float accumulatedBoostTime = 0f;
    public float powerupSpeed = 0;
    public bool boostable = true;
    public bool subtractSecond = false;
    public bool powerActive = false;

    public Image boostBar;

    public Vector3 movement;

    [SerializeField] ParticleSystem boostParticle;
    [SerializeField] ParticleSystem defaultParticle;


    public void Start()
    {
        movementSpeed = startSpeed;
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("HealthPickup"))
        {
            PlayerStats.Health += 20;
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("SpeedPickup"))
        {
            powerupSpeed += 20;
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("DmgPickup"))
        {
            PlayerAttack.attackpickup += 5;
            other.gameObject.SetActive(false);
        }

    }


    IEnumerator SpecialPower()
    {
        powerActive = true;
        movementSpeed = boostSpeed + 15;
        yield return new WaitForSeconds(5);
        powerActive = false;
    }


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
            
            
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            float threedmovement = Input.GetAxis("threedmovement");

            Vector3 moveVector = (transform.right * horizontal) + (transform.forward * vertical) + (transform.up * threedmovement);


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
                movementSpeed = startSpeed + powerupSpeed;
            }

            
            if (!boostable && !subtractSecond)
            {
                StartCoroutine(boostRecharge());
                accumulatedBoostTime = 0;
                
                
            }

            if (PlayerAttack.abilityActivated)
            {
                StartCoroutine(SpecialPower());
            }
            
            movement = moveVector;
            CC.Move(moveVector * movementSpeed * Time.deltaTime);
        }
    }
}
