using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpForce = 10.0f;
    
    //groundchecks
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    //this is so it will only detect what we want (not detecting player for ground check)
    public LayerMask groundMask;
       
    
    private Vector3 velocity;
    private bool isGrounded;
    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            //this sets default to slightly press down on the player 
            velocity.y = -1f;
        }
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        //the right transform is a directional vector -1 - 1, same for forward 
        //so its just making a vector based on the amounts of the axis input then 
        //position + move * speed thing
        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * (speed * Time.deltaTime));

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = jumpForce * Time.deltaTime;
        }
        
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
