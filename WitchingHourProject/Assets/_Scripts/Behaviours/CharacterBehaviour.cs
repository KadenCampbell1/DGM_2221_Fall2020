using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterBehaviour : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 movement, lookDirection, reverseScale;
    public float gravity = -20f, regularGravity = -20f, reverseGravity = 20f, yAxisVar;
    public FloatData speed, normalSpeed, fastSpeed, jumpForce, regularJumpForce, reverseJumpForce;
    public IntData jumpMax;
    private int jumpCount;
    public BoolData flippedGravity;
    

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        speed = normalSpeed;
        //reverseScale.Set(1, -1, 1);
        //reverseScale.Set(180,0,0);
    }

    public void FlipGravity()
    {
        flippedGravity.value = !flippedGravity.value;
    }

    private void Update()
    {
        // if (flippedGravity.value)
        // {
        //     gravity = reverseGravity;
        //     jumpForce = reverseJumpForce;
        //     gameObject.transform.localScale = reverseScale;
        //     //gameObject.transform.rotation = Quaternion.Euler(reverseScale);
        //     
        //     if (controller.isGrounded && movement.y > 0)
        //     {
        //         yAxisVar = 1;
        //         jumpCount = 0;
        //     }
        // }
        // else
        // {
        //     gravity = regularGravity;
        //     jumpForce = regularJumpForce;
        //     gameObject.transform.localScale = Vector3.one;
        //     //gameObject.transform.rotation = Quaternion.Euler(Vector3.zero);
        //     
        //     if (controller.isGrounded && movement.y < 0)
        //     {
        //         yAxisVar = -1;
        //         jumpCount = 0;
        //     }
        // }
        
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
