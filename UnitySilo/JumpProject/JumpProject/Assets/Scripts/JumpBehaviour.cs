using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class JumpBehaviour : MonoBehaviour
{
    private CharacterController controller;
    private float gravity = -9.81f;
    private Vector3 movement;
    private float yAxisVar;
    //On combination change int values to ScriptableObjects except jumpCount
    public int jumpForce, jumpCount, jumpMax;
    
    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        yAxisVar += gravity * Time.deltaTime;
        
        if (controller.isGrounded && movement.y < 0)
        {
            yAxisVar = -1;
            jumpCount = 0;
        }
        
        if (Input.GetButtonDown("Jump") && jumpCount < jumpMax)
        {
            yAxisVar = jumpForce;
            jumpCount++;
        }
        movement.Set(0, yAxisVar, 0);

        controller.Move(movement * Time.deltaTime);
    }
}
