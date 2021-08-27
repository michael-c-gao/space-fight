using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    public Transform target;
    public GameObject[] targetArray;
    public float movementSpeed = 10.0f;
    public float rotationOffset = 0.4f;
    Vector3 dist;
    float fov;
    float enemyFOV;
    public GameObject gunPos;
    bool subtractSecond = false;
    public TrailRenderer tracerRound;
    public GameObject gunBarrel;
    public GameObject impact;


    void Start()
    {
        target = targetArray[loadCharacter.character].transform;
    }

    void Update()
    {
        if (!Pause.isPaused && !GameOver.isGameOver)
        {
            RotateTowardsPlayer();
            MoveTowardsPlayer();
            LookingAt();
        }
    }

    IEnumerator Countdown()
    {
        subtractSecond = true;
        PlayerStats.Health -= 10;
        yield return new WaitForSeconds(1);
        subtractSecond = false;
    }

    void RotateTowardsPlayer()
    {
        Vector3 movePosition = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(movePosition);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationOffset * Time.deltaTime);
    }

    void MoveTowardsPlayer()
    {
        if (Vector3.Distance(target.position, transform.position) >= 5)
        {
            transform.position += transform.forward * movementSpeed * Time.deltaTime;
        }
    }

    void LookingAt()
    {
        dist = transform.position - target.position;
        fov = Vector3.Angle(transform.forward, dist);
        enemyFOV = Mathf.Abs(fov);
        if (enemyFOV > 150 && enemyFOV < 240)
        {
            Shooting();
            //Debug.DrawLine(transform.position, target.position, Color.red);
        }
    }

    void Shooting()
    {
        RaycastHit hit;
        if (Physics.Raycast(gunPos.transform.position, transform.forward, out hit))
        {
            if (hit.transform.CompareTag("MainCamera") && !subtractSecond) {
                StartCoroutine(Countdown());
                var tracer = Instantiate(tracerRound, gunBarrel.transform.position, Quaternion.identity);
                tracer.AddPosition(gunBarrel.transform.position);
                tracer.transform.position = hit.point;
                //GameObject impactMark = Instantiate(impact, hit.point, Quaternion.LookRotation(hit.normal));
                //Destroy(impactMark, 3f);
                //Debug.DrawRay(gunPos.transform.position, transform.forward * 10000, Color.green);
            }
        }
    }

}
