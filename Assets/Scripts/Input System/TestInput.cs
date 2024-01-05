using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestInput : MonoBehaviour
{
    public Vector2 movementAxis;

    PlayerActions inputActions;

    private void OnEnable()
    {
        if (inputActions == null)
        {
            inputActions = new PlayerActions();
            inputActions.PlayerControls.Movement.performed += MoveTest;
            inputActions.PlayerControls.Movement.canceled += Stop;

            inputActions.PlayerControls.Attack.performed += i => print("Attacked!");
        }

        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    void MoveTest(InputAction.CallbackContext callbackContext)
    {
        movementAxis = callbackContext.ReadValue<Vector2>();
    }
    void Stop(InputAction.CallbackContext callbackContext)
    {
        movementAxis = Vector2.zero;
    }

}
