using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class WalkAndRun : MonoBehaviour
{
    //Change float speeds into FloatDatas
    public float moveSpeed, normalSpeed = 4f, fastSpeed = 7.5f;
    private Rigidbody rBody;
    private void Start()
    {
        rBody = GetComponent<Rigidbody>();
        moveSpeed = normalSpeed;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire3"))
        {
            moveSpeed = fastSpeed;
        }
        else if (Input.GetButtonUp("Fire3"))
        {
            moveSpeed = normalSpeed;
        }
    }
    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        

        Vector3 movement = new Vector3(horizontal, 0, vertical) * (moveSpeed * Time.deltaTime);
        var lookDirection = new Vector3(horizontal + 0.001f, 0f, vertical);
        
        rBody.MovePosition(gameObject.transform.position + movement);
        rBody.MoveRotation(Quaternion.LookRotation(lookDirection));
        // if (!rBody.IsSleeping())
        // {
        //     transform.rotation = Quaternion.LookRotation(lookDirection);
        // }
    }
}
