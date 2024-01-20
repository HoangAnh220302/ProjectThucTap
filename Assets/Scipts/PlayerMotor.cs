using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelo;
    [SerializeField] public float Speed;
    private bool isGrounded;
    private float Grav = -9.8f;
    private float jumpHeight = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded= controller.isGrounded;
    }
    //receive the inputs for our PlayerMovement.cs and apply them to our character controller
    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * Speed * Time.deltaTime);
        playerVelo.y += Grav * Time.deltaTime;
        if(!isGrounded && playerVelo.y < 0) {
            playerVelo.y = -2f;        
        }
        controller.Move(playerVelo* Time.deltaTime);
    }
    public void Jump()
    {
        if(isGrounded)
        {
            //Grav = -9.8f
            //jumpHeight = 3.0f
            playerVelo.y = Mathf.Sqrt(jumpHeight * -3.0f * Grav);
        }
    }
}
