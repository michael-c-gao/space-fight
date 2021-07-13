using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dash : MonoBehaviour
{
    move movementScript;
    public float dashSpeed;
    public float dashTime;
    public float cooldown;
    private float lastDashed = -9999f;
    [SerializeField] ParticleSystem article;


    void Start()
    {
        movementScript = GetComponent<move>();
    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time > lastDashed + cooldown)
            {
                StartCoroutine(Dash());
                lastDashed = Time.time;
            }


        }


        IEnumerator Dash()
        {
            float starT = Time.time;

            while (Time.time < starT + dashTime)
            {
                movementScript.CC.Move(movementScript.movement * dashSpeed * Time.deltaTime);
                article.Emit(10);


                yield return null;
            }
        }
    }
}
