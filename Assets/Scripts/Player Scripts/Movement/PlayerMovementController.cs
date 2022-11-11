using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementController : MonoBehaviour
{
    private Vector2 direction;
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
