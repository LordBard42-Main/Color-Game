using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovement
{
    public void Move();
    public Vector2 GetPosition();
    public void SetPosition(Vector2 position);
    public Vector2 GetMovementVector();
    public void SetMovementVector(Vector2 movementVector);
    public bool GetIfICanMove();
    public void SetIfICanMove(bool canMove);
}
