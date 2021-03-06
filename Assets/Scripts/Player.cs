﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    //as i am not doing any sqr roots to make the jump force be equal to the y axis height the force has to be
    //a big number
    public float jumpForce = 10.0f;
    //Since player uses raycasts I cant have a invis wall to stop the player from running onto the spawning floor
    //so i have to limit its postition
    public float zLimit = -13;

    public Vector3 velocity = new Vector3(0,0,0);
    bool isGrounded = true;
    private bool holdingSpace = false;
    
    
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    
    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        //if the velocity is 0 then -1 is set so it does not affect the jump force
        if (isGrounded && velocity.y < 0)
            velocity.y = -1.0f;

        Vector3 move = transform.right * x + transform.forward * z;
        if (transform.position.z > zLimit && move.z > 0)
            move.z = 0f;

        controller.Move(move * (speed * Time.deltaTime));

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            holdingSpace = true;
            velocity.y = jumpForce;
        }
        
        if (Input.GetKeyUp(KeyCode.Space))
            holdingSpace = false;

        if (!isGrounded && !holdingSpace)
        {
            velocity.y += gravity * Time.deltaTime;
        }
        
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
