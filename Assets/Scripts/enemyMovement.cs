using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    public Transform target;
    public GameObject[] targetArray;
    public float movementSpeed = 10.0f;
    public float rotationalDamp = 0.4f;

    void Start()
    {
        target = targetArray[loadCharacter.character].transform;
    }

    void Update()
    {
        RotateTowardsPlayer();
        MoveTowardsPlayer();
    }

    void RotateTowardsPlayer()
    {
        Vector3 movePosition = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(movePosition);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationalDamp * Time.deltaTime);
    }

    void MoveTowardsPlayer()
    {
        transform.position += transform.forward * movementSpeed * Time.deltaTime;
    }
}
