using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullScreenJoystickToggle : MonoBehaviour
{
    [SerializeField] private GameObject FullscreenJoystick;
    [SerializeField] private Button fullScreenJoystickButton;

    private Color selectedColor = Color.yellow;
    private Color defaultColor = Color.white;
    private void Start()
    {
        FullscreenJoystick.gameObject.SetActive(false);
    }
    /// <summary>
    /// Function to switch the full screen joystick on and off
    /// </summary>
    public void SwitchOnOff()
    {
        if (FullscreenJoystick.activeSelf == true) FullscreenJoystick.SetActive(false);
        else FullscreenJoystick.SetActive(true);

        if (FullscreenJoystick.activeSelf == false)
        {
            fullScreenJoystickButton.image.color = defaultColor;

         
        }
        else fullScreenJoystickButton.image.color = selectedColor;
        
    }
}
