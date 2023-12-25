using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float walkSpeed = 12f; // Yürüme hýzý
    public float runSpeed = 18f;  // Koþma hýzý
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    

    public Transform GroundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;


    Vector3 velocity;
    bool isGrounded;
    

    void Start()
    {
        
    }

    private bool isRunning = false;

    void Update()
    {
        isGrounded = Physics.CheckSphere(GroundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -5f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        


        float currentSpeed = isRunning ? runSpeed : walkSpeed;

        controller.Move(move * currentSpeed * Time.deltaTime);

        
            controller.Move(move * walkSpeed * Time.deltaTime);

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);

            // Koþma kontrolü ekleyin
            isRunning = Input.GetKey("left shift"); // Varsayýlan olarak "LeftShift" tuþunu kullanabilirsiniz.
        
    }
}
