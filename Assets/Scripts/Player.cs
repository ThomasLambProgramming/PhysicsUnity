using System.Collections;
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


    public Vector3 velocity = new Vector3(0,0,0);
    bool isGrounded = true;


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
        controller.Move(move * (speed * Time.deltaTime));

        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = jumpForce;
            
        }
        
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
