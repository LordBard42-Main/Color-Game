using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : IState
{
    private PlayerMovement playerMovement;
    public MoveState(PlayerMovement playerMovement)
    {
        this.playerMovement = playerMovement;
    }
    public void OnEnter()
    {
        Debug.Log("Enter Move State");
    }

    public void OnExit()
    {
    }

    public void Tick()
    {
        playerMovement.Move();
    }
}
