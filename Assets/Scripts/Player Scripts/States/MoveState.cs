using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : IState
{
    private PlayerInputManager playerInputManager;
    private PlayerMovementController playerMovement;
    public MoveState(PlayerMovementController playerMovement, PlayerInputManager playerInputManager)
    {
        this.playerMovement = playerMovement;
        this.playerInputManager = playerInputManager;
    }
    public void OnEnter()
    {
        //Debug.Log("Enter Move State");
        playerInputManager.OnMovementPressed += SetDirection;
        playerInputManager.OnMovementReleased += ReleaseDirection;
    }

    public void OnExit()
    {
        playerInputManager.OnMovementPressed -= SetDirection;
        playerInputManager.OnMovementReleased -= ReleaseDirection;
    }

    public void Tick()
    {
        playerMovement.Move();
    }
    private void SetDirection(Vector2 direction)
    {
        if (direction.y != 0 && direction.x != 0)
            direction -= playerMovement.Direction;

        playerMovement.Direction = direction;
    }
    private void ReleaseDirection(Vector2 direction)
    {
        playerMovement.Direction = new Vector2(0, 0);

    }
}
