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


    public delegate void InjectTargetFound();
    public event InjectTargetFound OnInjectTargetFound;

    public delegate void SiphonTargetFound();
    public event SiphonTargetFound OnSiphonTargetFound;

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

    public bool CheckForInjectionTarget()
    {
        if (colorProperties.CurrentColor == Colors.White)
        {
            return false;
        }

        var hit = Physics2D.Raycast((Vector2)spriteTransform.position + (direction * .5f), direction, 1 - .1f);

        if (hit)
        {
            if (hit.transform.TryGetComponent(out ColorProperties hitObject))
            {
                injectionTarget = hitObject;
                OnInjectTargetFound!?.Invoke();
                return true;
            }
        }
        return false;
    }
    public void CheckForAbsorbtionTarget()
    {
        if (colorProperties.CurrentColor == Colors.Purple || colorProperties.CurrentColor == Colors.Orange || 
            colorProperties.CurrentColor == Colors.Green)
        {
            return;
        }

        var hit = Physics2D.Raycast((Vector2)spriteTransform.position + (direction * .5f), direction, 1 - .1f);

        if (hit)
        {
            if (hit.transform.TryGetComponent(out ColorProperties hitObject))
            {
                if(hitObject.CurrentColor != Colors.White)
                {
                    absorbtionTarget = hitObject;
                    Debug.Log(OnSiphonTargetFound);
                    OnSiphonTargetFound!?.Invoke();
                }
            }
        }
    }

    public bool InjectTarget(Colors color)
    {
        var canAdd = injectionTarget.CheckIfColorCanBeAdded(color);
        
        if(canAdd)
            injectionTarget.AddColor(color);

        injectionTarget = null;
        return canAdd;
    }
    public void AbsorbFromTarget(Colors color)
    {
        absorbtionTarget.RemoveColor(color);
        absorbtionTarget = null;
    }

    public void SetDirectionFacing(Vector2 direction)
    {
        this.direction = direction;
    }
}
