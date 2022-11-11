using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AbsorbState : IState
{
    private PlayerInputManager playerInputManager;
    private ColorSelector colorSelector;
    private ColorProperties playerColorProperties;
    private ColorInjector colorInjector;
    private Camera camera;

    public AbsorbState(PlayerInputManager playerInputManager, ColorSelector colorSelector, ColorProperties playerColorProperties, ColorInjector colorInjector, Camera camera)
    {
        this.playerInputManager = playerInputManager;
        this.colorSelector = colorSelector;
        this.playerColorProperties = playerColorProperties;
        this.colorInjector = colorInjector;
        this.camera = camera;
    }


    public void OnEnter()
    {

        Debug.Log("Enter Inject State");
        playerInputManager.OnFire1Pressed += Fire1;
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
        playerInputManager.OnFire1Pressed -= Fire1;
        colorSelector.OnColorSelected -= ColorSelected;
    }

    public void Tick()
    {
    }


    private void ColorSelected(Colors color)
    {
        var canAdd = playerColorProperties.CheckIfColorCanBeAdded(color);

        if (canAdd)
        {
            playerColorProperties.AddColor(color);
            colorInjector.AbsorbFromTarget(color);
        }
        else
            colorInjector.AbsorbtionTarget = null;
    }
    private void Fire1()
    {
        colorInjector.AbsorbtionTarget = null;
        colorSelector.CloseColorSelection();
    }
}
