using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public float speed = 12f;
    public float gravityMultiplier = 1.5f;
    public float gravity = -9.81f;
    public float height = 2f;

    Vector3 vel;
    bool isGrounded;

    void Start()
    {
        gravity *= gravityMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && vel.y < 0) {
            vel.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded) {
            vel.y = Mathf.Sqrt(height * -2f * gravity);
        }

        vel.y += gravity * Time.deltaTime;

        controller.Move(vel * Time.deltaTime);
    }
}
