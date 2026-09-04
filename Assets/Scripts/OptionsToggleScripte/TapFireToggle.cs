using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapFireToggle : MonoBehaviour
{


    [SerializeField] private GameObject tapGesture;
    [SerializeField] private Button tapGestureButton;

    private Color selectedColor = Color.yellow;
    private Color defaultColor = Color.white;
    private void Start()
    {
        tapGesture.gameObject.SetActive(false);
    }
    /// <summary>
    /// Function to switch the tap gesture on and off
    /// </summary>
    public void SwitchOnOff()
    {
        if (tapGesture.activeSelf == true) tapGesture.SetActive(false);
        else tapGesture.SetActive(true);

        if (tapGesture.activeSelf == false)
        {
            tapGestureButton.image.color = defaultColor;


        }
        else tapGestureButton.image.color = selectedColor;

    }
}
