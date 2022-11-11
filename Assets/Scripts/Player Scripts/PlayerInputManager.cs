using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{

    private PlayerInput playerInput;

    public PlayerInput PlayerInput { get => playerInput; }

    public delegate void Fire1Pressed();
    public event Fire1Pressed OnFire1Pressed;

    public delegate void Fire2Pressed();
    public event Fire2Pressed OnFire2Pressed;

    public delegate void CycleRightPressed();
    public event CycleRightPressed OnCycleRightPressed;

    public delegate void CycleLeftPressed();
    public event CycleLeftPressed OnCycleLeftPressed;

    public delegate void MovementPressed(Vector2 direction);
    public event MovementPressed OnMovementPressed;

    public delegate void MovementReleased(Vector2 direction);
    public event MovementReleased OnMovementReleased;

    public delegate void EscapePressed();
    public event EscapePressed OnEscape;

    #region  Singleton

    public static PlayerInputManager instance;

    private void Awake()
    {

        if (instance != null)
        {
            Debug.LogWarning("PlayerInputManager already exists");
            Destroy(gameObject);
            return;
        }
        playerInput = GetComponent<PlayerInput>();
        instance = this;

    }
    #endregion

    public void Fire_1(InputAction.CallbackContext context)
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (context.performed)
        {
            OnFire1Pressed?.Invoke();

        }
    }
    public void Fire_2(InputAction.CallbackContext context)
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

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
    public void MovementInput(InputAction.CallbackContext context)
    {

        var direction = context.ReadValue<Vector2>();
        if (context.canceled)
        {
            OnMovementReleased?.Invoke(direction);
            
        }

        else if (context.performed)
        {
            OnMovementPressed?.Invoke(direction);
        }
        


    }
    public void Escape(InputAction.CallbackContext context)
    { 
        if (context.started)
        {
            OnEscape?.Invoke();
        }
    }

}
