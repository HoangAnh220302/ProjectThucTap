using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Movement playerInput;
    public Movement.PlayerMovementActions playerMovement;
    private PlayerMotor motor;
    // Start is called before the first frame update
    private PlayerLook look;
    void Awake()
    {
        playerInput = new Movement();
        playerMovement = playerInput.PlayerMovement;
        motor = GetComponent<PlayerMotor>();
        playerMovement.Jumper.performed += ctx => motor.Jump();
        look = GetComponent<PlayerLook>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        motor.ProcessMove(playerMovement.Stafe.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        playerMovement.Enable();
    }

    private void OnDisable()
    {
        playerMovement.Disable();
    }
    private void LateUpdate()
    {
        look.Proccessed_Look(playerMovement.Look.ReadValue<Vector2>());
    }
}
