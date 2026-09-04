using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsButton : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private GameObject pauseButton;
    /// <summary>
    /// Function to set the options menu to active and the main menu to inactive
    /// </summary>
    public void OptionsPressed()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
        pauseButton.SetActive(false);
    }
    /// <summary>
    /// Function to set the main menu to active and the options menu to inactive
    /// </summary>
    public void BackButtonPressed()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }
}
