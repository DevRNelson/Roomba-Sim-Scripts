using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
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
    public static InputAction sprintAction;
    private Vector3 respawnPosition;
    private Quaternion respawnRotation;

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


    public float currentSpeed;
    public float baseSpeed = 4f;
    public float rotationSpeed = 50f;
    public float rotationSharpSpeed = 200f;
    public float backwardSpeed = 5f;
    public float sprintSpeed = 8f;

    private void Start()
    {
        // Set initial respawn positions to the player's starting position
        respawnPosition = transform.position;
        respawnRotation = Quaternion.Euler(0, 0, 0); // resets player model's rotation axis to 0 to ensure it flips the model to the default position

        //PLAYER INPUTS/KEYBINDS VALUE LISTENERS
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


    //  Player Control Binds BEGINS
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

        // Check if the player presses the "R" key or the Select/Reset Button on Gamepad
        if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.JoystickButton6))  //6 is the select button on gamepad
        {
            // Respawn the player at the previously stored positioning
            transform.position = respawnPosition;
            transform.rotation = respawnRotation;
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
        if (GlobalVariables.canMove == true)
        {
            if ((wPressed && iPressed) || (leftStickUpPressed && rightStickUpPressed))
            {
                transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
            }
        }
    }

    private void MoveBackward()
    {
        if (GlobalVariables.canMove == true)
        {
            if ((sPressed && kPressed) || (leftStickDownPressed && rightStickDownPressed))
            {
                transform.Translate(-Vector3.forward * currentSpeed * Time.deltaTime);
            }
        }
    }

    private void MoveLeft()
    {
        if (GlobalVariables.canMove == true)
        {
            if ((aPressed && jPressed) || (leftStickLeftPressed && rightStickLeftPressed))
            {
                transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
            }
        }
    }

    private void MoveRight()
    {
        if (GlobalVariables.canMove == true)
        {
            if ((dPressed && lPressed) || (leftStickRightPressed && rightStickRightPressed))
            {
                transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
            }
        }
    }
    private void MoveSharpLeft()
    {
        if (GlobalVariables.canMove == true)
        {
            if ((sPressed && iPressed) || (leftStickDownPressed && rightStickUpPressed))
            {
                transform.Rotate(Vector3.up, -rotationSharpSpeed * Time.deltaTime);
            }
        }
    }

    private void MoveSharpRight()
    {
        if (GlobalVariables.canMove == true)
        {
            if ((wPressed && kPressed) || (leftStickUpPressed && rightStickDownPressed))
            {
                transform.Rotate(Vector3.up, rotationSharpSpeed * Time.deltaTime);
            }
        }
    }
    //  Player Control Binds  End

    // RESPAWN CODE BEGINS      (THIS SAVES THE INITIAL POSITIONS OF THE  PLAYER WHEN SPAWNED (OR AT LEAST IT SHOULD LMAO!!))
    public void SetRespawnPosition(Vector3 newPosition)
    {

        respawnPosition = newPosition;
    }

    public void SetRespawnRotation(Quaternion newRotation)
    {

        respawnRotation = newRotation;
    }

    // RESPAWN CODE end

    private InputAction CreateInputAction(string binding, System.Action<InputAction.CallbackContext> action)
    {
        var inputAction = new InputAction(binding: binding, interactions: "press");
        inputAction.performed += action;
        inputAction.canceled += ctx => action.Invoke(default);
        inputAction.Enable();

        return inputAction;
    }
}