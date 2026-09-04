using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRateTarget : MonoBehaviour
{
    /// <summary>
    /// uses the awake function to set the target frame rate to 120 fps
    /// this then makes older devices run at 60 fps
    /// </summary>
    private void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 120;
    }
}
