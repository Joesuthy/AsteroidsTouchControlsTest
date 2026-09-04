using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireButtonToggle : MonoBehaviour
{
    
    [SerializeField] private GameObject fireButtonUI;
    [SerializeField] private Button fireToggleButton;

    private Color selectedColor = Color.yellow;
    private Color defaultColor = Color.white;
    private void Start()
    {
        fireButtonUI.gameObject.SetActive(true);
        fireToggleButton.image.color = selectedColor;
    }
    /// <summary>
    /// Function to switch the fire button on and off
    /// </summary>
    public void SwitchOnOff()
    {
        if (fireButtonUI.activeSelf == true) fireButtonUI.SetActive(false);
        else fireButtonUI.SetActive(true);

        if (fireButtonUI.activeSelf == false)
        {
            fireToggleButton.image.color = defaultColor;


        }
        else fireToggleButton.image.color = selectedColor;

    }
}
