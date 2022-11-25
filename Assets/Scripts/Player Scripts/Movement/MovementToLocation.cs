using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This IMovement class willl move an Object to a specific Vector
/// </summary>
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

    /// <summary>
    /// This is the method where the movement takes place
    /// </summary>
    public void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, destination, Time.deltaTime * speed);

        if (transform.position.Equals(destination))
        {
            OnDestinationReached?.Invoke();
        }
    }

    /// <summary>
    /// This gets the objects position
    /// </summary>
    /// <returns>Transform.position</returns>
    public Vector2 GetPosition()
    {
        return transform.position;
    }

    /// <summary>
    /// Sets the transforms's postion instantly
    /// </summary>
    /// <param name="position"></param>
    public void SetPosition(Vector2 position)
    {
        transform.position = position;
    }

    /// <summary>
    /// Get the directional vector the object is moving
    /// </summary>
    /// <returns></returns>
    public Vector2 GetMovementVector()
    {
        return destination;
    }

    /// <summary>
    /// Set the directional vector for the object to move along
    /// </summary>
    /// <param name="movementVector"></param>
    public void SetMovementVector(Vector2 movementVector)
    {
        destination = movementVector;
    }

    /// <summary>
    /// Get whether the object is currently allowed to move
    /// </summary>
    /// <returns></returns>
    public bool GetIfICanMove()
    {
        return canMove;
    }

    /// <summary>
    /// Set's whether or not the object can move
    /// </summary>
    /// <param name="canMove"></param>
    public void SetIfICanMove(bool canMove)
    {
        this.canMove = canMove;
    }

}
