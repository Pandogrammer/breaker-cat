using System;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] private CharacterController controller;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumpHeight = 3f;
    [SerializeField] private float gravity = -9.81f;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;

    private Vector3 velocity;
    private bool isGrounded;

    private void Update()
    {
        Move();
        Jump();
    }

    private void Jump()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        
        if (isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
        }
        
        velocity.y += gravity * Time.deltaTime;
        velocity.y = Mathf.Max(velocity.y, gravity);

        controller.Move(velocity);
    }

    private void Move()
    {
        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");
        var move = transform.right * x + transform.forward * z;
        controller.Move(move * (speed * Time.deltaTime));
    }
}