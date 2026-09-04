using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseBackButton : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenu;

    /// <summary>
    /// Function to set the time scale to 1 and set the pause menu to inactive
    /// </summary>
    public void BackPressed()
    {
        Time.timeScale = 1;
        PauseMenu.SetActive(false);

    }
}
