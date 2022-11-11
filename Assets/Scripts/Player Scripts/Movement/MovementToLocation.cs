using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementToLocation : MonoBehaviour, IMovement
{
    //Transform to Be moved
    [SerializeField]
    private new Transform transform;

    //Speed at which Object is Moved
    [SerializeField]
    private float speed;

    //Destination That object is moving Towards
    private Vector2 destination;

    //Can the object be moved
    private bool canMove = false;


    //Event Triggered When Transform reaches Destination
    public delegate void DestinationReached();
    public event DestinationReached OnDestinationReached;
    public bool CanMove { get => canMove; set => canMove = value; }

    private void Awake()
    {
        destination = transform.position;
    }

    public void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, destination, Time.deltaTime * speed);

        if (transform.position.Equals(destination))
        {
            OnDestinationReached?.Invoke();
        }
    }

    public Vector2 GetPosition()
    {
        return transform.position;
    }

    public void SetPosition(Vector2 position)
    {
        transform.position = position;
    }
    public Vector2 GetMovementVector()
    {
        return destination;
    }

    public void SetMovementVector(Vector2 movementVector)
    {
        destination = movementVector;
    }

    public bool GetIfICanMove()
    {
        return canMove;
    }

    public void SetIfICanMove(bool canMove)
    {
        this.canMove = canMove;
    }

}
