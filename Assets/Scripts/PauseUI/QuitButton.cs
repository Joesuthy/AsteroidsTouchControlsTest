using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitButton : MonoBehaviour
{
    /// <summary>
    /// Function to load the main menu scene and set the time scale to 1
    /// </summary>
    public void OnQuitButtonClicked()
    {
        
        SceneManager.LoadScene("MainScene");
        Time.timeScale = 1;
    }

}
