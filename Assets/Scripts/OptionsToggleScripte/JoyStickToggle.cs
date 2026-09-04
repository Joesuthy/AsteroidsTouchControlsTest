using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoyStickToggle : MonoBehaviour
{
    [SerializeField] private GameObject joystickUI;
    [SerializeField] private Button joystickButton;

    private Color selectedColor = Color.yellow;
    private Color defaultColor = Color.white;
    private void Start()
    {
        joystickUI.gameObject.SetActive(true);
        joystickButton.image.color = selectedColor;
    }
    /// <summary>
    /// Function to switch the joystick on and off
    /// </summary>
    public void SwitchOnOff()
    {
        if (joystickUI.activeSelf == true) joystickUI.SetActive(false);
        else joystickUI.SetActive(true);

        if (joystickUI.activeSelf == false)
        {
            joystickButton.image.color = defaultColor;


        }
        else joystickButton.image.color = selectedColor;

    }


}
