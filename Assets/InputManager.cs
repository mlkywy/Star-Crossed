using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// This script acts as a single point for all other scripts to get
// the current input from. It uses Unity's new Input System and
// functions should be mapped to their corresponding controls
// using a PlayerInput component with Unity Events.

[RequireComponent(typeof(PlayerInput))]
public class InputManager : MonoBehaviour
{
    private Vector2 _moveDirection = Vector2.zero;
    private bool _interactPressed = false;
    private bool _submitPressed = false;
    private bool _shootPressed = false;
    private bool _startPressed = false;

    private static InputManager _instance;

    private void Awake()
    {
        if (_instance != null)
        {
            Debug.LogError("Found more than one Input Manager in the scene.");
        }
        _instance = this;
    }

    public static InputManager GetInstance() 
    {
        return _instance;
    }

    public void MovePressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _moveDirection = context.ReadValue<Vector2>();
        }
        else if (context.canceled)
        {
            _moveDirection = context.ReadValue<Vector2>();
        } 
    }

    public void InteractButtonPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _interactPressed = true;
        }
        else if (context.canceled)
        {
            _interactPressed = false;
        } 
    }

    public void SubmitButtonPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _submitPressed = true;
        }
        else if (context.canceled)
        {
            _submitPressed = false;
        } 
    }

    public void ShootButtonPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _shootPressed = true;
        }
        else if (context.canceled)
        {
            _shootPressed = false;
        } 
    }

    public void StartButtonPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            _startPressed = true;
        }
        else if (context.canceled)
        {
            _startPressed = false;
        } 
    }

    public Vector2 GetMoveDirection() 
    {
        return _moveDirection;
    }

    // for any of the below 'Get' methods, if we're getting it then we're also using it,
    // which means we should set it to false so that it can't be used again until actually
    // pressed again.

    public bool GetInteractPressed() 
    {
        bool result = _interactPressed;
        _interactPressed = false;
        return result;
    }

    public bool GetSubmitPressed() 
    {
        bool result = _submitPressed;
        _submitPressed = false;
        return result;
    }

    public bool GetShootPressed() 
    {
        bool result = _shootPressed;
        _shootPressed = false;
        return result;
    }

    public bool GetStartPressed() 
    {
        bool result = _startPressed;
        _startPressed = false;
        return result;
    }

    public void RegisterSubmitPressed() 
    {
        _submitPressed = false;
    }
}