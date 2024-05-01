using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RoombaMovement : MonoBehaviour
{
    private InputAction moveForwardWAction;
    private InputAction moveForwardIAction;
    private InputAction moveBackwardSAction;
    private InputAction moveBackwardKAction;
    private InputAction moveLeftAAction;
    private InputAction moveLeftJAction;
    private InputAction moveRightDAction;
    private InputAction moveRightLAction;
    private InputAction moveLeftStickLeftAction;
    private InputAction moveRightStickLeftAction;
    private InputAction moveLeftStickRightAction;
    private InputAction moveRightStickRightAction;
    private InputAction moveLeftStickUpAction;
    private InputAction moveRightStickUpAction;
    private InputAction moveLeftStickDownAction;
    private InputAction moveRightStickDownAction;
    private InputAction sprintAction;

    private bool wPressed = false;
    private bool iPressed = false;
    private bool sPressed = false;
    private bool kPressed = false;
    private bool aPressed = false;
    private bool jPressed = false;
    private bool dPressed = false;
    private bool lPressed = false;
    private bool leftStickLeftPressed = false;
    private bool rightStickLeftPressed = false;
    private bool leftStickRightPressed = false;
    private bool rightStickRightPressed = false;
    private bool leftStickUpPressed = false;
    private bool rightStickUpPressed = false;
    private bool leftStickDownPressed = false;
    private bool rightStickDownPressed = false;
    
    public static bool isSprinting = false;

    //hi this is a test comment
    public float currentSpeed;
    public float baseSpeed = 4f;
    public float rotationSpeed = 50f;
    public float rotationSharpSpeed = 200f;
    public float backwardSpeed = 5f;
    public float sprintSpeed = 8f;

    private void Start()
    {
        moveForwardWAction = CreateInputAction("<Keyboard>/w", ctx => wPressed = ctx.ReadValue<float>() > 0.5f);
        moveForwardIAction = CreateInputAction("<Keyboard>/i", ctx => iPressed = ctx.ReadValue<float>() > 0.5f);
        moveBackwardSAction = CreateInputAction("<Keyboard>/s", ctx => sPressed = ctx.ReadValue<float>() > 0.5f);
        moveBackwardKAction = CreateInputAction("<Keyboard>/k", ctx => kPressed = ctx.ReadValue<float>() > 0.5f);
        moveLeftAAction = CreateInputAction("<Keyboard>/a", ctx => aPressed = ctx.ReadValue<float>() > 0.5f);
        moveLeftJAction = CreateInputAction("<Keyboard>/j", ctx => jPressed = ctx.ReadValue<float>() > 0.5f);
        moveRightDAction = CreateInputAction("<Keyboard>/d", ctx => dPressed = ctx.ReadValue<float>() > 0.5f);
        moveRightLAction = CreateInputAction("<Keyboard>/l", ctx => lPressed = ctx.ReadValue<float>() > 0.5f);
        sprintAction = CreateInputAction("<Keyboard>/leftShift", ctx => isSprinting = ctx.ReadValueAsButton());
        sprintAction = CreateInputAction("<Gamepad>/rightTrigger", ctx => isSprinting = ctx.ReadValue<float>() > 0.5f);
        moveLeftStickLeftAction = CreateInputAction("<Gamepad>/leftStick/left", ctx => leftStickLeftPressed = ctx.ReadValue<float>() > 0.5f);
        moveRightStickLeftAction = CreateInputAction("<Gamepad>/rightStick/left", ctx => rightStickLeftPressed = ctx.ReadValue<float>() > 0.5f);
        moveLeftStickRightAction = CreateInputAction("<Gamepad>/leftStick/right", ctx => leftStickRightPressed = ctx.ReadValue<float>() > 0.5f);
        moveRightStickRightAction = CreateInputAction("<Gamepad>/rightStick/right", ctx => rightStickRightPressed = ctx.ReadValue<float>() > 0.5f);
        moveLeftStickUpAction = CreateInputAction("<Gamepad>/leftStick/up", ctx => leftStickUpPressed = ctx.ReadValue<float>() > 0.5f);
        moveRightStickUpAction = CreateInputAction("<Gamepad>/rightStick/up", ctx => rightStickUpPressed = ctx.ReadValue<float>() > 0.5f);
        moveLeftStickDownAction = CreateInputAction("<Gamepad>/leftStick/down", ctx => leftStickDownPressed = ctx.ReadValue<float>() > 0.5f);
        moveRightStickDownAction = CreateInputAction("<Gamepad>/rightStick/down", ctx => rightStickDownPressed = ctx.ReadValue<float>() > 0.5f);
    }

    private void Update()
    {
        if (isSprinting)
        {
            currentSpeed = sprintSpeed;
        }
        else
        {
            currentSpeed = baseSpeed;
        }    
        

        MoveForward();
        MoveBackward();
        MoveLeft();
        MoveRight();
        MoveSharpLeft(); 
        MoveSharpRight();
    }

    private void MoveForward()
    {
        if ((wPressed && iPressed) || (leftStickUpPressed && rightStickUpPressed))
        {
            transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
        }
    }

    private void MoveBackward() 
    {
        if ((sPressed && kPressed) || (leftStickDownPressed && rightStickDownPressed))
        {
            transform.Translate(-Vector3.forward * currentSpeed * Time.deltaTime);
        }
    }

    private void MoveLeft()
    {
        if ((aPressed && jPressed) || (leftStickLeftPressed && rightStickLeftPressed))
        {
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        }
    }

    private void MoveRight()
    {
        if ((dPressed && lPressed) || (leftStickRightPressed && rightStickRightPressed))
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }
    private void MoveSharpLeft()
    {
        if ((sPressed && iPressed) || (leftStickDownPressed && rightStickUpPressed))
        {
            transform.Rotate(Vector3.up, -rotationSharpSpeed * Time.deltaTime);
        }
    }

    private void MoveSharpRight()
    {
        if ((wPressed && kPressed) || (leftStickUpPressed && rightStickDownPressed))
        {
            transform.Rotate(Vector3.up, rotationSharpSpeed * Time.deltaTime);
        }
    }

    private InputAction CreateInputAction(string binding, System.Action<InputAction.CallbackContext> action)
    {
        var inputAction = new InputAction(binding: binding, interactions: "press");
        inputAction.performed += action;
        inputAction.canceled += ctx => action.Invoke(default);
        inputAction.Enable();

        return inputAction;
    }
}
