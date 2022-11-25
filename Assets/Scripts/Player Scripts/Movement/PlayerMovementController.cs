using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// This class is a controller class for player movement.
/// It controlls movement with Movement Rules
/// </summary>
public class PlayerMovementController : MonoBehaviour
{
    private Vector2 direction;

    //This is where my interface is implemented. The reason I am using an interface here is I decoupled the physical movement script from my Controller script. 
    //This will give myself the flexibility to swap out or change movement scripts without having to worry about tampering the code in this class.
    //Recently my goal is to get closer to single responsibility classes.
    private IMovement movement;
    private MovementRules movementRules = new MovementRules();

    public bool CanMove { get => movement.GetIfICanMove(); set => movement.SetIfICanMove(value); }
    public Vector2 Position { get => movement.GetPosition(); set => movement.SetPosition(value); } 
    public Vector2 Direction { get => direction; set => direction = value; }
    public MovementRules MovementRules { get => movementRules; }

    public void Move() => movement.Move();

    private void Awake()
    {
        movement = GetComponent<IMovement>();
    }

    public bool IsPositionDifferentThenDestination()
    {
        return !Position.Equals(movement.GetMovementVector());
    }

    public void SetDestination(Vector2 destination)
    {
        movement.SetMovementVector(destination);
    }

    public void TeleportPlayer(Vector2 location)
    {
        movement.SetPosition(location);
        movement.SetMovementVector(location);
    }

}
