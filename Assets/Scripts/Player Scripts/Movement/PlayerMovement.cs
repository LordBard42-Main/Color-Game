using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] 
    private new Transform transform;


    [SerializeField]
    private float speed;


    private Vector2 destination;

    private bool canMove = false;

    public bool CanMove { get => canMove; set => canMove = value; }
    public Vector2 Position { get => Transform.position; set => Transform.position = value; }
    public Transform Transform { get => transform; }

    private void Awake()
    {
        destination = Transform.position;
    }
   
    public void Move()
    {
        Transform.position = Vector2.MoveTowards(Transform.position, destination, Time.deltaTime * speed);
    }

    public bool IsPositionDifferentThenDestination()
    {
        return !Transform.position.Equals(destination);
    }

    public void SetDestination(Vector2 destination)
    {
        this.destination = destination;
    }

    public void TeleportPlayer(Vector2 location)
    {
        Transform.position = location;
        destination = location;
    }
}
