using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Companion : IGameObject
{
    private CompanionMovementController companionMovementController;
    private ColorProperties colorProperties;



    private void Awake()
    {
        companionMovementController = GetComponent<CompanionMovementController>();
        colorProperties = GetComponent<ColorProperties>();
    }

    private void Start()
    {
       
    }

    private void Update()
    {
        companionMovementController.Move();
    }

    public override void ForceApplied(Vector2 force)
    {
        var position = companionMovementController.Position;
        var canMove = companionMovementController.MovementRules.CheckMovement(position, force, colorProperties);
        

        if (canMove.Item1)
            companionMovementController.SetDestination(canMove.Item2);
    }

}
