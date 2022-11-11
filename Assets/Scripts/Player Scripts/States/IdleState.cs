using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    private PlayerInputManager playerInputManager;
    private PlayerMovementController playerMovement;
    private PointerController pointerController;
    private ColorInjector colorInjector;
    private ColorProperties colorProperties;

    public IdleState(PlayerInputManager playerInputManager, PlayerMovementController playerMovement, ColorInjector colorInjector,
                        PointerController pointerController, ColorProperties colorProperties)
    {
        this.playerInputManager = playerInputManager;
        this.playerMovement = playerMovement;
        this.colorInjector = colorInjector;
        this.pointerController = pointerController;
        this.colorProperties = colorProperties;
    }

    public void OnEnter()
    {
        //Debug.Log("Enter Idle State");
        playerMovement.CanMove = true;
        playerInputManager.OnMovementPressed += SetDirection;
        playerInputManager.OnMovementReleased += ReleaseDirection;
        playerInputManager.OnFire1Pressed += CheckForInjectionTarget;
        playerInputManager.OnFire2Pressed += CheckForAbsorbtionTarget;
        playerInputManager.OnCycleLeftPressed += RotateLeft;
        playerInputManager.OnCycleRightPressed += RotateRight;

        if (playerMovement.Direction.y != 0 || playerMovement.Direction.x != 0)
            AttemptToMove(playerMovement.Direction);
    }

    public void OnExit()
    {
        playerMovement.CanMove = false;
        playerInputManager.OnMovementPressed -= SetDirection;
        playerInputManager.OnMovementReleased -= ReleaseDirection;
        playerInputManager.OnFire1Pressed -= CheckForInjectionTarget;
        playerInputManager.OnFire2Pressed -= CheckForAbsorbtionTarget;
        playerInputManager.OnCycleLeftPressed -= RotateLeft;
        playerInputManager.OnCycleRightPressed -= RotateRight;
    }

    public void Tick()
    {
    }

    private void SetDirection(Vector2 direction)
    {
        if (direction.y != 0 && direction.x != 0)
            direction -= playerMovement.Direction;

        playerMovement.Direction = direction;
        AttemptToMove(direction);
    }
    private void ReleaseDirection(Vector2 direction)
    {
        playerMovement.Direction = new Vector2(0,0);
    }

    public void AttemptToMove(Vector2 direction)
    {
        if (playerMovement.CanMove)
        {

            var result = playerMovement.MovementRules.CheckMovement(playerMovement.Position, direction, colorProperties);

            var moveAvailable = result.Item1;

            if (moveAvailable)
            {
                var destination = result.Item2;
                playerMovement.SetDestination(destination);
            }

        }

    }

    public void CheckForInjectionTarget()
    {
        colorInjector.CheckForInjectionTarget();
    } 
    public void CheckForAbsorbtionTarget()
    {
        colorInjector.CheckForAbsorbtionTarget();
    }

    public void RotateRight()
    {
        pointerController.RotateRight();
    }

    private void RotateLeft()
    {
        pointerController.RotateLeft();
    }

}
