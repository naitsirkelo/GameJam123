using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcMovement : MonoBehaviour
{
    public CharacterController controller;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public float gravityMultiplier = 1.5f;
    public float gravity = -9.81f;

    float timer;
    float timeToChange = 2f;
    float minTime = 1f;
    float maxTime = 3f;

    float speed = 4f;
    float minSpeed = 2f;
    float maxSpeed = 6f;

    float x;
    float z;

    Vector3 vel;
    bool isGrounded;

    void Start()
    {
        gravity *= gravityMultiplier;

        x = Random.Range(-1f, 1f);
        z = Random.Range(-1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && vel.y < 0) {
            vel.y = -2f;
        }

        timer += Time.deltaTime;

        if (timer > timeToChange) {

            x = Random.Range(-1f, 1f);
            z = Random.Range(-1f, 1f);

            timeToChange = Random.Range(minTime, maxTime);
            speed = Random.Range(minSpeed, maxSpeed);
            timer = 0f;
        }

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        vel.y += gravity * Time.deltaTime;

        controller.Move(vel * Time.deltaTime);

    }
}
