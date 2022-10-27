using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using System;

public class PlayerController : MonoBehaviour
{
    //Movement
    [SerializeField]
    private MovementRules movementRules;

    [SerializeField]
    private PlayerMovement playerMovement;

    [SerializeField]
    private ColorProperties playerColorProperties;


    public void MovementInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            var direction = context.ReadValue<Vector2>();

            if (playerMovement.CanMove)
            {
                var result = movementRules.CheckMovement(playerMovement.Position, direction);

                var moveAvailable = result.Item1;

                if(moveAvailable)
                {
                    var destination = result.Item2;
                    playerMovement.SetDestination(destination);
                }

            }
        }


    }

    
}
