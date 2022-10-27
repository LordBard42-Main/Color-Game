using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    private PlayerInputHandler playerInputManager;
    private PlayerMovement playerMovement;
    private PointerController pointerController;
    private ColorInjector colorInjector;
    private ColorProperties colorProperties;

    public IdleState(PlayerInputHandler playerInputManager,PlayerMovement playerMovement, ColorInjector colorInjector, 
                        PointerController pointerController, ColorProperties colorProperties )
    {
        this.playerInputManager = playerInputManager;
        this.playerMovement = playerMovement;
        this.colorInjector = colorInjector;
        this.pointerController = pointerController;
        this.colorProperties = colorProperties;
    }

    public void OnEnter()
    {
        Debug.Log("Enter Idle State");
        playerMovement.CanMove = true;
        playerInputManager.OnFire1Pressed += CheckForInjectionTarget;
        playerInputManager.OnFire2Pressed += CheckForAbsorbtionTarget;
        playerInputManager.OnCycleLeftPressed += RotateLeft;
        playerInputManager.OnCycleRightPressed += RotateRight;
    }

    public void OnExit()
    {
        playerMovement.CanMove = false;
        playerInputManager.OnFire1Pressed -= CheckForInjectionTarget;
        playerInputManager.OnFire2Pressed -= CheckForAbsorbtionTarget;
        playerInputManager.OnCycleLeftPressed -= RotateLeft;
        playerInputManager.OnCycleRightPressed -= RotateRight;
    }

    public void Tick()
    {
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
