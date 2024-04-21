using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class InputManager : MonoBehaviour
{
    private Vector2 moveDirection = Vector2.zero;

    private bool interactPressed = false;
    private bool submitPressed = false;
    private bool startPressed = false;
    private bool selectPressed = false;
    private bool buttonRB = false;
    private bool buttonLB = false;
    private bool buttonY = false;
    private bool buttonX = false;
    private bool buttonRight = false;
    private bool buttonUp = false;
    private bool buttonDown = false;
    private bool buttonLeft = false;
    private float buttonLt;
    private float buttonRt;  
    public void MovePressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            moveDirection = context.ReadValue<Vector2>();
        }
        else if (context.canceled)
        {
            moveDirection = context.ReadValue<Vector2>();
        }
    }
    public void InteractButtonPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            interactPressed = true;
        }
        else if (context.canceled)
        {
            interactPressed = false;
        }
    }
    public void SubmitPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            submitPressed = true;
        }
        else if (context.canceled)
        {
            submitPressed = false;
        }
    }

    public void StartButtonPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            startPressed = true;
        }
        else if (context.canceled)
        {
            startPressed = false;
        }
    }
    public void SelectButtonPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            selectPressed = true;
        }
        else if (context.canceled)
        {
            selectPressed = false;
        }
    }

    public void ButtonY(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            buttonY = true;
        }
        else if (context.canceled)
        {
            buttonY = false;
        }
    }
    public void ButtonX(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            buttonX = true;
        }
        else if (context.canceled)
        {
            buttonX = false;
        }
    }
    public void ButtonRB(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            buttonRB = true;
        }
        else if (context.canceled)
        {
            buttonRB = false;
        }
    }

    public void ButtonLB(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            buttonLB = true;
        }
        else if (context.canceled)
        {
            buttonLB = false;
        }
    }
    public void ButtonUp(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            buttonUp = true;
        }
        else if (context.canceled)
        {
            buttonUp = false;
        }
    }
    public void ButtonDown(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            buttonDown = true;
        }
        else if (context.canceled)
        {
            buttonDown = false;
        }
    }
    public void ButtonRight(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            buttonRight = true;
        }
        else if (context.canceled)
        {
            buttonRight = false;
        }
    }
    public void ButtonLeft(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            buttonLeft = true;
        }
        else if (context.canceled)
        {
            buttonLeft = false;
        }
    }

    public void ButtonLtPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
            buttonLt = context.ReadValue<float>();
        else if (context.canceled)
            buttonLt = context.ReadValue<float>();
    }
    public void ButtonRtPressed(InputAction.CallbackContext context)
    {
        if (context.performed)
            buttonRt = context.ReadValue<float>();
        else if (context.canceled)
            buttonRt = context.ReadValue<float>();
    }
    // 
    public Vector2 GetMoveDirection() { return moveDirection; }
    public float GetButtonLtPressed() { return buttonLt; }
    public float GetButtonRtPressed() { return buttonRt; }

    public bool GetInteractPressed()
    {
        bool result = interactPressed;
        submitPressed = false;
        return result;
    }

    public bool GetSubmitPressed()
    {
        bool result = submitPressed;
        submitPressed = false;
        return result;
    }

    public bool GetStartPressed()
    {
        bool result = startPressed;
        startPressed = false;
        return result;
    }
    public bool GetSelectPressed()
    {
        bool result = selectPressed;
        selectPressed = false;
        return result;
    }
    public bool GetButtonY()
    {
        bool result = selectPressed;
        buttonY = false;
        return result;
    }
    public bool GetButtonX()
    {
        bool result = selectPressed;
        buttonX = false;
        return result;
    }
    public bool GetButtonRB()
    {
        bool result = selectPressed;
        buttonRB = false;
        return result;
    }

    public bool GetButtonLB()
    {
        bool result = selectPressed;
        buttonLB = false;
        return result;
    }
    public bool GetButtonUp()
    {
        bool result = selectPressed;
        buttonLB = false;
        return result;
    }
    public bool GetButtonDown()
    {
        bool result = selectPressed;
        buttonDown = false;
        return result;
    }
    public bool GetButtonLeft()
    {
        bool result = selectPressed;
        buttonLeft = false;
        return result;
    }
    public bool GetButtonRight()
    {
        bool result = selectPressed;
        buttonRight = false;
        return result;
    }
    public void RegisterSubmitPressed()
    {
        submitPressed = false;
    }
}
