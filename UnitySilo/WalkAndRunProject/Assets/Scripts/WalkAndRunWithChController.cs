using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class WalkAndRunWithChController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 movement, lookDirection;
    private float gravity = -9.81f;
    public float speed = 4f, normalSpeed = 4f, fastSpeed = 7.5f;
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        speed = normalSpeed;

    }

    private void Update()
    {
        var vInput = Input.GetAxis("Vertical");
        var hInput = Input.GetAxis("Horizontal");
        
        if (Input.GetButtonDown("Fire3"))
        {
            speed = fastSpeed;
        }
        else if (Input.GetButtonUp("Fire3"))
        {
            speed = normalSpeed;
        }

        lookDirection.Set(hInput, 0, vInput);
                
        if (lookDirection != Vector3.zero)
        {
            gameObject.transform.forward = lookDirection;
        }
        
        movement.Set(hInput, gravity, vInput);
        controller.Move(movement * (speed * Time.deltaTime));
        
    }
}
