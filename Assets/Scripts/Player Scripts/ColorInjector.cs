using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class ColorInjector : MonoBehaviour
{
    private Vector2 direction;

    private ColorProperties colorProperties;
    private ColorProperties injectionTarget;
    private ColorProperties absorbtionTarget;

    [SerializeField]
    private ColorSelector colorSelector;

    [SerializeField]
    private Transform spriteTransform;

    //Direction Driver
    private IDirectional directionalDriver;

    public ColorProperties InjectionTarget { get => injectionTarget; set => injectionTarget = value; }
    public ColorProperties AbsorbtionTarget { get => absorbtionTarget; set => absorbtionTarget = value; }

    private void Awake()
    {
        colorProperties = GetComponentInChildren<ColorProperties>();
        directionalDriver = GetComponentInChildren<IDirectional>();

    }

    private void Start()
    {
        directionalDriver.OnDirectionUpdated += SetDirectionFacing;
        SetDirectionFacing(Vector2.right);
    }

    private void OnDestroy()
    {
        directionalDriver.OnDirectionUpdated -= SetDirectionFacing;
    }

    internal void CancelInjection()
    {
        injectionTarget = null;
    }

    public void CheckForInjectionTarget()
    {
        if (colorProperties.CurrentColor == PrimaryColors.White)
        {
            return;
        }

        var hit = Physics2D.Raycast((Vector2)spriteTransform.position + (direction * .5f), direction, 1 - .1f);

        if (hit)
        {
            if (hit.transform.TryGetComponent(out ColorProperties hitObject))
            {
                injectionTarget = hitObject;
            }
        }
    }
    public void CheckForAbsorbtionTarget()
    {
        Debug.Log("Checking");
        if (colorProperties.CurrentColor == PrimaryColors.Purple || colorProperties.CurrentColor == PrimaryColors.Orange || 
            colorProperties.CurrentColor == PrimaryColors.Green)
        {
            return;
        }



        var hit = Physics2D.Raycast((Vector2)spriteTransform.position + (direction * .5f), direction, 1 - .1f);

        if (hit)
        {
            if (hit.transform.TryGetComponent(out ColorProperties hitObject))
            {
                if(hitObject.CurrentColor != PrimaryColors.White)
                    absorbtionTarget = hitObject;
            }
        }
    }

    public bool InjectTarget(PrimaryColors color)
    {
        var wasAdded = injectionTarget.AddColor(color);
        injectionTarget = null;
        return wasAdded;
    }
    public void AbsorbFromTarget(PrimaryColors color)
    {
        absorbtionTarget.RemoveColor(color);
        absorbtionTarget = null;
    }

    public void SetDirectionFacing(Vector2 direction)
    {
        this.direction = direction;
    }
}
