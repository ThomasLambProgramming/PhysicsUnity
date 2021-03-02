using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public float mouseSensHorizontal = 100.0f;
    public float mouseSensVertical = 100.0f;
    public Transform player;
    private float xRotation = 0f;
    private bool followMouse = true;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (followMouse)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensVertical * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensHorizontal * Time.deltaTime;
            xRotation -= mouseY * Time.deltaTime;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            player.Rotate(Vector3.up * (mouseX * Time.deltaTime));
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            followMouse = !followMouse;
            Cursor.lockState = CursorLockMode.Locked;

        }
    }
}
