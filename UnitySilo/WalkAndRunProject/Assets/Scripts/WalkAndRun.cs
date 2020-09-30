using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class WalkAndRun : MonoBehaviour
{
    public float moveSpeed, normalSpeed = 30f, fastSpeed = 50f;
    private Rigidbody rBody;
    private void Start()
    {
        rBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Fire3"))
        {
            moveSpeed = fastSpeed;
        }
        else if (Input.GetButtonUp("Fire3"))
        {
            moveSpeed = normalSpeed;
        }

        Vector3 movement = new Vector3(horizontal, 0, vertical) * (moveSpeed * Time.deltaTime);
        
        rBody.MovePosition(gameObject.transform.position + movement);
    }
}
