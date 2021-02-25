using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMover : MonoBehaviour
{
    private Animator animator;
    public Transform Camera;
    public float speed;
    private bool jumpInput = false;
    CharacterController cc;
    Vector2 moveINput = new Vector2();
    public Vector3 velocity;
    public float jumpVelocity;
    bool isGrounded = true;
    
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveINput.x = Input.GetAxis("Horizontal");
        moveINput.y = Input.GetAxis("Vertical");
        jumpInput = Input.GetButton("Jump");

        animator.SetFloat("Forwards", moveINput.y);
        animator.SetBool("Jump", !isGrounded);
    }
    private void FixedUpdate()
    {
        Vector3 camForward = Camera.forward;
        camForward.y = 0;
        camForward.Normalize();
        Vector3 camRight = Camera.right;
        transform.forward = camForward;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
        }

        Vector3 delta;
        delta = (moveINput.x * camRight + moveINput.y * camForward) * speed;
        if (isGrounded || moveINput.x != 0.0f || moveINput.y != 0.0f)
        {
            velocity.x = delta.x;
            velocity.z = delta.z;
        }
        if (jumpInput && isGrounded)
        {
            velocity.y = jumpVelocity;
        }
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0;
        }
        velocity += Physics.gravity * Time.fixedDeltaTime;

        if (!isGrounded)
            hitDirection = Vector3.zero;

        if (moveINput.x == 0 && moveINput.y == 0)
        {
            Vector3 horizontalHitDirection = hitDirection;
            horizontalHitDirection.y = 0;
            float displacement = horizontalHitDirection.magnitude;
            if (displacement > 0)
                velocity -= 0.2f * horizontalHitDirection / displacement;
        }


        cc.Move(velocity * Time.deltaTime);
        isGrounded = cc.isGrounded;

    }

    public Vector3 hitDirection;
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        hitDirection = hit.point - transform.position;
    }
}
