using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeGestureToggle : MonoBehaviour
{
    
    [SerializeField] private GameObject swipGesture;
    [SerializeField] private Button swipeGestureButton;

    private Color selectedColor = Color.yellow;
    private Color defaultColor = Color.white;
    private void Start()
    {
        swipGesture.gameObject.SetActive(false);
    }
    /// <summary>
    /// Function to switch the swipe gesture on and off
    /// </summary>
    public void SwitchOnOff()
    {
        if (swipGesture.activeSelf == true) swipGesture.SetActive(false);
        else swipGesture.SetActive(true);

        if (swipGesture.activeSelf == false)
        {
            swipeGestureButton.image.color = defaultColor;


        }
        else swipeGestureButton.image.color = selectedColor;

    }
}
