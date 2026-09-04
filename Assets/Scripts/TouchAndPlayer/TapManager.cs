using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TapManager : MonoBehaviour
{
    [SerializeField] private float tapThreshold = 10f; 
    private Vector2 startTouchPosition;
    private bool isTap = false;

    public delegate void OnTapDetected(Vector2 position);
    public static event OnTapDetected TapEvent;
    /// <summary>
    /// Detects a tap on the screen and invokes the TapEvent with the position of the tap
    /// </summary>
    private void Update()
    {
        if (Touchscreen.current == null) return;

        if (Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
        {
            startTouchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
            isTap = true;
        }

        if (Touchscreen.current.primaryTouch.press.isPressed)
        {
            Vector2 currentPosition = Touchscreen.current.primaryTouch.position.ReadValue();
            if (Vector2.Distance(startTouchPosition, currentPosition) > tapThreshold)
            {
                isTap = false; 
            }
        }

        if (Touchscreen.current.primaryTouch.press.wasReleasedThisFrame && isTap)
        {
            Vector2 tapPosition = Touchscreen.current.primaryTouch.position.ReadValue();
            TapEvent?.Invoke(tapPosition);
        }
    }
}
