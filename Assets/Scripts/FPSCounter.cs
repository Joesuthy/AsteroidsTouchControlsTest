using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class FPSCounter : MonoBehaviour
{
    public TMP_Text fpsText; 

    private float updateInterval = 0.5f;
    private float accum = 0;
    private int frames = 0;
    private float timeleft;

    void Start()
    {
        timeleft = updateInterval;
    }

    /// <summary>
    /// uses the update function to display the fps on the screen
    /// </summary>
    void Update()
    {
        timeleft -= Time.deltaTime;
        accum += Time.timeScale / Time.deltaTime;
        ++frames;

        if (timeleft <= 0.0)
        {
            float fps = accum / frames;
            fpsText.text = Mathf.Round(fps).ToString() + " FPS";
            timeleft = updateInterval;
            accum = 0;
            frames = 0;
        }

        
    }
}
