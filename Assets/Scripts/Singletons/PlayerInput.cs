using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public static ButtonState PrimaryActionButton => Input.GetMouseButtonDown(0) ? ButtonState.Pressed :
        Input.GetMouseButtonUp(0) ? ButtonState.Released :
        Input.GetMouseButton(0) ? ButtonState.Pressing :
        ButtonState.Untouched;

    public static ButtonState SecondaryActionButton => Input.GetMouseButtonDown(1) ? ButtonState.Pressed :
        Input.GetMouseButtonUp(1) ? ButtonState.Released :
        Input.GetMouseButton(1) ? ButtonState.Pressing :
        ButtonState.Untouched;

    public static ButtonState MobilityButton => Input.GetButtonDown("Jump") ? ButtonState.Pressed :
        Input.GetButtonUp("Jump") ? ButtonState.Released :
        Input.GetButton("Jump") ? ButtonState.Pressing :
        ButtonState.Untouched;

    public static ButtonState SecondaryMobilityButton => Input.GetButtonDown("Jump") ? ButtonState.Pressed :
        Input.GetButtonUp("Jump") ? ButtonState.Released :
        Input.GetButton("Jump") ? ButtonState.Pressing :
        ButtonState.Untouched;
}

public enum ButtonState
{
    Untouched,
    Pressed,
    Pressing,
    Released
}