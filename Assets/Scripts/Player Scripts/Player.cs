using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IGameObject
{
    [SerializeField]
    private PlayerInputHandler playerInputHandler;

    [SerializeField]
    private PlayerMovement playerMovement;

    [SerializeField]
    private ColorProperties colorProperties;

    [SerializeField]
    private ColorSelector colorSelector;

    [SerializeField]
    private ColorInjector colorInjector;

    [SerializeField]
    private PointerController pointerController;

    [SerializeField]
    private new Camera camera;

    private StateMachine playerStateMachine;

    public bool CanMoveInto()
    {
        throw new NotImplementedException();
    }

  

    private void Awake()
    {
        playerStateMachine = new StateMachine();
    }

    private void Start()
    {
        var idleState = new IdleState(playerInputHandler, playerMovement, colorInjector, pointerController, colorProperties);
        var moveState = new MoveState(playerMovement);
        var injectState = new InjectState(colorSelector, colorProperties, colorInjector, camera);
        var absorbState = new AbsorbState(colorSelector, colorProperties, colorInjector, camera);
        
        At(to: idleState, from: moveState, condition: move());
        At(to: moveState, from: idleState, condition: idle());
        At(to: idleState, from: injectState, condition: inject());
        At(to: idleState, from: absorbState, condition: absorb());
        At(to: injectState, from: idleState, condition: idle());
        At(to: absorbState, from: idleState, condition: idle());


        void At(IState to, IState from, Func<bool> condition) => playerStateMachine.AddTransition(from: to, to: from, condition);



        Func<bool> move() => () => playerMovement.IsPositionDifferentThenDestination();
        Func<bool> idle() => () => !playerMovement.IsPositionDifferentThenDestination() && !playerMovement.CanMove
                                       && colorInjector.InjectionTarget == null && colorInjector.AbsorbtionTarget == null;
        Func<bool> inject() => () => colorInjector.InjectionTarget != null;
        Func<bool> absorb() => () => colorInjector.AbsorbtionTarget != null;


        playerStateMachine.SetState(idleState);

    }

    private void Update()
    {
        playerStateMachine.Tick();
    }
}
