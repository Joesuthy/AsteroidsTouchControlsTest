using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject PauseButton;


    [SerializeField] private GameObject gameManager;
    [SerializeField] private GameObject player;

    private void Start()
    {
        gameManager.SetActive(false);
        player.SetActive(false);
        PauseButton.SetActive(false);
    }
    /// <summary>
    /// Funcion to start the game and set the game objects to active and sets the time scale to 1
    /// </summary>
    public void StartGame()
    {
        
        mainMenu.SetActive(false);
        PauseButton.SetActive(true);
        gameManager.SetActive(true);    
        player.SetActive(true);
        Time.timeScale = 1f;
    }
}
