using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseMovement : MonoBehaviour
{
    private float rotationSensitivity;
    public Transform playerRotate;
    float XRotation = 0f;
    public static bool isPaused = false;


    void Start()
    {
        rotationSensitivity = 125;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    void Update()
    {
        if (!GameOver.isGameOver && !Pause.isPaused)
        {
            rotationSensitivity = SensSlider.sliderValue;
            float Xaxis = Input.GetAxis("Mouse X") * rotationSensitivity * Time.deltaTime;
            float Yaxis = Input.GetAxis("Mouse Y") * rotationSensitivity * Time.deltaTime;

            XRotation -= Yaxis;

            transform.localRotation = Quaternion.Euler(XRotation, 0f, 0f);
            playerRotate.Rotate(Vector3.up * Xaxis);
        }
    }
}
