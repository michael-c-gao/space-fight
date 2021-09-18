using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    public GameObject arena;
    public Transform arena1;
    public Transform thix;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(arena.transform.position, Vector3.right, 5 * Time.deltaTime);
        //thix.LookAt(arena1);
    }
}
