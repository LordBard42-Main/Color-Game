using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AbsorbState : IState
{
    private ColorSelector colorSelector;
    private ColorProperties playerColorProperties;
    private ColorInjector colorInjector;
    private Camera camera;

    public AbsorbState(ColorSelector colorSelector, ColorProperties playerColorProperties, ColorInjector colorInjector, Camera camera)
    {
        this.colorSelector = colorSelector;
        this.playerColorProperties = playerColorProperties;
        this.colorInjector = colorInjector;
        this.camera = camera;
    }


    public void OnEnter()
    {

        Debug.Log("Enter Inject State");
        colorSelector.OnColorSelected += ColorSelected;


        var mousePosition = Mouse.current.position.ReadValue();
        var worldPosition = camera.ScreenToWorldPoint(mousePosition);

        colorSelector.StartCoroutine(WaitForFrame());

        IEnumerator WaitForFrame()
        {
            yield return new WaitForEndOfFrame();
            colorSelector.OpenColorSelection(worldPosition, colorInjector.AbsorbtionTarget);
        }
    }

    public void OnExit()
    {
        colorSelector.OnColorSelected -= ColorSelected;
    }

    public void Tick()
    {
    }


    private void ColorSelected(PrimaryColors color)
    {
        var addedColor = playerColorProperties.AddColor(color);

        if (addedColor)
            colorInjector.AbsorbFromTarget(color);
        else
            colorInjector.AbsorbtionTarget = null;
    }
}
