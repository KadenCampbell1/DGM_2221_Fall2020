using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterBehaviour : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 movement, lookDirection;
    public float gravity = -40f, yAxisVar;
    public FloatData speed, normalSpeed, fastSpeed, jumpForce;
    public IntData jumpMax;
    private int jumpCount;
    public BoolData flippedGravity;
    

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        speed = normalSpeed;
    }

    public void FlipGravity()
    {
        flippedGravity.value = !flippedGravity.value;
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

        
        
        if (flippedGravity.value)
        {
            lookDirection.Set(verticalInput, 0, horizontalInput);
            movement.Set(verticalInput * speed.value, yAxisVar, horizontalInput * speed.value);
        }
        else
        {
            lookDirection.Set(verticalInput, 0, -horizontalInput);
            movement.Set(verticalInput * speed.value, yAxisVar, -horizontalInput * speed.value);
        }

        if (lookDirection == Vector3.zero)
        {
            lookDirection.Set(0.0001f, 0, 0.0001f);
        }
        
        if (horizontalInput > 0.5f || horizontalInput < -0.5f ||verticalInput > 0.5f || verticalInput < -0.5f)
        {
            transform.rotation = Quaternion.LookRotation(lookDirection);
        }

        controller.Move(movement * Time.deltaTime);
    }
}
