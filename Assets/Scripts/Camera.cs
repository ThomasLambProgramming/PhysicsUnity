using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public float mouseSensHorizontal = 100.0f;
    public float mouseSensVertical = 100.0f;
    public Transform player;
    private float xRotation = 0f;

    public TextMeshProUGUI text;

    float mouseX = 0f;
    float mouseY = 0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        text.text = "Mouse Sens X : " + mouseSensHorizontal + "\n" + "Mouse Sens Y : " + mouseSensVertical;

        float X = mouseX * mouseSensHorizontal;
        float Y = mouseY * mouseSensVertical;

        xRotation -= Y * Time.deltaTime;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        player.Rotate(Vector3.up * (X * Time.deltaTime));

        


    }

 

    
}
