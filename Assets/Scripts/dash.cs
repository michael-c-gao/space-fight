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
    [SerializeField] ParticleSystem dashParticle;


    void Start()
    {
        movementScript = GetComponent<move>();
    }

    IEnumerator Dash()
    {
        float starT = Time.time;
        while (Time.time < starT + dashTime)
        {
            movementScript.CC.Move(movementScript.movement * dashSpeed * Time.deltaTime);
            dashParticle.Emit(1);
            yield return null;
        }
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && !GameOver.isGameOver && !Pause.isPaused)
        {
            if (Time.time > lastDashed + cooldown)
            {
                StartCoroutine(Dash());
                lastDashed = Time.time;
            }
        }
    }

}
