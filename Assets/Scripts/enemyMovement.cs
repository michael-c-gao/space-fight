using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    public Transform target;
    public GameObject[] targetArray;
    public float movementSpeed = 10.0f;
    public float rotationalDamp = 0.4f;
    Vector3 newVector;
    float angleBetween;
    public GameObject gunPos;

    void Start()
    {
        target = targetArray[loadCharacter.character].transform;
    }

    void Update()
    {
        RotateTowardsPlayer();
        MoveTowardsPlayer();
        IsInFront();

    }

    void RotateTowardsPlayer()
    {
        Vector3 movePosition = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(movePosition);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationalDamp * Time.deltaTime);
    }

    void MoveTowardsPlayer()
    {
        if (Vector3.Distance(target.position, transform.position) >= 5)
        {
            transform.position += transform.forward * movementSpeed * Time.deltaTime;
        }
    }

    bool IsInFront()
    {
        newVector = transform.position - target.position;
        angleBetween = Vector3.Angle(transform.forward, newVector);
        float a = Mathf.Abs(angleBetween);
        bool retVal = false;
        if (Mathf.Abs(angleBetween) > 150 && Mathf.Abs(angleBetween) < 240)
        {
            Shot();
            Debug.DrawLine(transform.position, target.position, Color.red);
            retVal = true;
        }

        return retVal;
    }

    bool Shot()
    {
        RaycastHit hit;
        Vector3 direction = target.position - transform.position;
        bool retval = false;
        
        if (Physics.Raycast(gunPos.transform.position, transform.forward, out hit))
        {
            if (hit.transform.CompareTag("MainCamera")) {
                Debug.DrawRay(gunPos.transform.position, transform.forward * 10000, Color.green);
                retval = true;
            }
        }
        Debug.Log(retval);
        return retval;

    }
}
