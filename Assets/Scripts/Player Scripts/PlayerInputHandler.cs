using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{

    public delegate void Fire1Pressed();
    public event Fire1Pressed OnFire1Pressed;
    
    public delegate void Fire2Pressed();
    public event Fire2Pressed OnFire2Pressed;

    public delegate void CycleRightPressed();
    public event CycleRightPressed OnCycleRightPressed;

    public delegate void CycleLeftPressed();
    public event CycleLeftPressed OnCycleLeftPressed;

    public void Fire_1(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnFire1Pressed?.Invoke();

        }
    } 
    public void Fire_2(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnFire2Pressed?.Invoke();

        }
    }
    public void CycleLeft(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnCycleLeftPressed?.Invoke();
        }
    }

    public void CycleRight(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnCycleRightPressed?.Invoke();
        }
    }

}
