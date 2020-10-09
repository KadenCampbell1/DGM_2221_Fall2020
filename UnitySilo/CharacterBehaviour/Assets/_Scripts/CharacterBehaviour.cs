using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterBehaviour : MonoBehaviour
{
    private CharacterController controller;
    private float gravity = -9.81f, yAxisVar;
    private Vector3 movement, lookDirection;
    private bool canMove = true;
    
    private FloatData currentSpeed;
    public FloatData normalSpeed, fastSpeed, jumpForce;
    
    public int jumpCount;
    public IntData jumpMax;
    
    private WaitForFixedUpdate wffu = new WaitForFixedUpdate();

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        currentSpeed = normalSpeed;
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        canMove = true;
        while (canMove)
        {
            yield return wffu;
            
            yAxisVar += gravity * Time.deltaTime;
            
            if (Input.GetButtonDown("Fire3"))
            {
                currentSpeed = fastSpeed;
            }
            else if (Input.GetButtonDown("Fire3"))
            {
                currentSpeed = normalSpeed;
            }

            var vInput = Input.GetAxis("Vertical") * currentSpeed.value * Time.deltaTime;
            var hInput = Input.GetAxis("Horizontal") * currentSpeed.value * Time.deltaTime;

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

            lookDirection.Set(hInput, 0, vInput);
            
            if (lookDirection != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(lookDirection);
            }
            
            movement.Set(hInput, yAxisVar, vInput);
            controller.Move(movement);
        }
    }
}
