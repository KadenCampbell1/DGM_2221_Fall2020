using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJump : MonoBehaviour
{
    public CharacterController controller;
    private Vector3 playerVelocity;
    public int playerSpeed = 8;
    public int jumpHeight = 3;
    private float gravityValue = -9.81f;
    public int jumpCount = 1;
    public Vector3 move = Vector3.zero;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && (jumpCount < 3 || controller.isGrounded))
        {
            move.y = jumpHeight;
            jumpCount++;
        }

        move.x = Input.GetAxis("Horizontal");
        move.z = Input.GetAxis("Vertical");
        controller.Move(move * (Time.deltaTime * playerSpeed));

        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerSpeed = 16;
        }
        else
        {
            playerSpeed = 8;
        }

        if (controller.isGrounded)
        {
            jumpCount = 1;
        }
        else
        {
            //Move.y has gravity multiplied by deltaTime
            move.y += gravityValue * Time.deltaTime;
        }


        //Character faces the direction it is moving
        playerVelocity.Set(move.x, 0, move.z);

        if (playerVelocity != Vector3.zero)
        {
            gameObject.transform.forward = playerVelocity;
        }
       
        
    }
}
