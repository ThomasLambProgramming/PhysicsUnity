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
    
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        text.text = "Mouse Sens X : " + mouseSensHorizontal + "\n" + "Mouse Sens Y : " +  mouseSensVertical;
        
        float mouseX = Input.GetAxis("Mouse X") * mouseSensHorizontal;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensVertical;
        xRotation -= mouseY * Time.deltaTime;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        player.Rotate(Vector3.up * (mouseX * Time.deltaTime));
    }

    
}
