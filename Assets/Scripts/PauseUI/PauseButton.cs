using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{

    [SerializeField] private GameObject PauseMenu;
    /// <summary>
    /// Function to set the time scale to 0 and set the pause menu to active
    /// </summary>
    public void PausePressed()
    {
        Time.timeScale = 0;
        PauseMenu.SetActive(true);

    }
}
