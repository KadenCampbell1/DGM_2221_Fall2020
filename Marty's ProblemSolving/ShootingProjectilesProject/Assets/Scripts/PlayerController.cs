using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 20;
   
    private Rigidbody rbody;
    
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        float horAxis = Input.GetAxis("Horizontal");
        float vertAxis = Input.GetAxis("Vertical");
       
        if (Input.GetKey(KeyCode.LeftShift))
            moveSpeed = 50;
        else
           moveSpeed = 20;
       
        var movement = new Vector3(horAxis, 0, vertAxis) * (moveSpeed * Time.deltaTime);

        rbody.MovePosition(transform.position + movement);
    }
}
