using UnityEngine;
using UnityEngine.InputSystem;

public class TouchManager : MonoBehaviour
{
    [SerializeField] private float swipeThreshold = 50f; 
    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    private bool isSwiping = false;

    public delegate void OnSwipeDetected(Vector2 direction);
    public static event OnSwipeDetected SwipeEvent;
    /// <summary>
    /// Detects a swipe on the screen and invokes the SwipeEvent with the direction of the swipe
    /// </summary>
    private void Update()
    {
        if (Touchscreen.current == null) return;

        if (Touchscreen.current.primaryTouch.press.isPressed)
        {
            if (!isSwiping)
            {
                startTouchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
                isSwiping = true;
            }
        }
        else if (isSwiping)
        {
            endTouchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
            DetectSwipe();
            isSwiping = false;
        }
    }
    /// <summary>
    /// Detects the swipe direction and invokes the SwipeEvent
    /// </summary>
    private void DetectSwipe()
    {
        Vector2 swipeDelta = endTouchPosition - startTouchPosition;

        if (swipeDelta.magnitude >= swipeThreshold)
        {
            Vector2 swipeDirection = swipeDelta.normalized;
            SwipeEvent?.Invoke(swipeDirection); 
        }
    }
}
