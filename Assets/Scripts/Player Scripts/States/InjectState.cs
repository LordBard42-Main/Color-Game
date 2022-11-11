using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InjectState : IState
{

    private PlayerInputManager playerInputManager;
    private ColorSelector colorSelector;
    private ColorProperties playerColorProperties;
    private ColorInjector colorInjector;
    private Camera camera;
    public InjectState(PlayerInputManager playerInputManager, ColorSelector colorSelector, ColorProperties playerColorProperties, ColorInjector colorInjector, Camera camera)
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
        colorSelector.OnColorSelected += ColorSelected;
        playerInputManager.OnFire1Pressed += Fire1;


        var mousePosition = Mouse.current.position.ReadValue();
        var worldPosition = camera.ScreenToWorldPoint(mousePosition);

        colorSelector.StartCoroutine(WaitForFrame());

        IEnumerator WaitForFrame()
        {
            yield return new WaitForEndOfFrame();
            colorSelector.OpenColorSelection(worldPosition, playerColorProperties);
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
        var wasInjected = colorInjector.InjectTarget(color);
        
        if (wasInjected) 
            playerColorProperties.RemoveColor(color);
        else
            colorInjector.InjectionTarget = null;
    }

    private void Fire1()
    {
        colorInjector.InjectionTarget = null;
        colorSelector.CloseColorSelection();
    }
}
