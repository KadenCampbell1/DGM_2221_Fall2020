using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterBehaviour : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 movement, lookDirection;
    private float gravity = -9.81f, yAxisVar;
    public FloatData speed, normalSpeed, fastSpeed, jumpForce;
    public IntData jumpMax;
    private int jumpCount;
    

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        speed = normalSpeed;
    }

    private void Update()
    {
        yAxisVar += gravity * Time.deltaTime;

        if (controller.isGrounded && movement.y < 0)
        {
            yAxisVar = -1;
            jumpCount = 0;
        }

        if (Input.GetButtonDown("Jump") && jumpCount < jumpMax.value)
        {
            yAxisVar = jumpForce.value;
            jumpCount++;
        }
        
        var verticalInput = Input.GetAxis("Vertical");
        var horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Fire3"))
        {
            speed = fastSpeed;
        }
        else if (Input.GetButtonUp("Fire3"))
        {
            speed = normalSpeed;
        }

        lookDirection.Set(horizontalInput, 0, verticalInput);

        if (lookDirection == Vector3.zero)
        {
            lookDirection.Set(0.0001f, 0, 0.0001f);
        }
        
        if (horizontalInput > 0.5f || horizontalInput < -0.5f ||verticalInput > 0.5f || verticalInput < -0.5f)
        {
            transform.rotation = Quaternion.LookRotation(lookDirection);
        }

        movement.Set(horizontalInput, yAxisVar, verticalInput);
        controller.Move(movement * (speed.value * Time.deltaTime));
    }
}
