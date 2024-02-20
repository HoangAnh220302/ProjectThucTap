using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    [SerializeField]
    private Gun Gun;
    [SerializeField]
    private Movement playerInput;
    public Movement.PlayerMovementActions playerMovement;

    private void OnEnable()
    {
        foreach (InputAction action in InputActions.actionMaps[0].actions)
        {
            if (action.name.Equals("Shoot"))
            {
                action.performed += HandleShoot;
            }
        }
    }

    private void OnDisable()
    {
        foreach (InputAction action in InputActions.actionMaps[0].actions)
        {
            if (action.name.Equals("Shoot"))
            {
                action.performed -= HandleShoot;
            }
        }
    }

    private void HandleShoot(InputAction.CallbackContext obj)
    {
        if (obj.performed)
        {
            Gun.Shoot();
        }
    }

    public void OnShoot()
    {
        Gun.Shoot();
    }
}
