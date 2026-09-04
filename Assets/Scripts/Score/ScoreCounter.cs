using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public static ScoreCounter Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI scoreCounter;
    [SerializeField] private TextMeshProUGUI endGameScoreCounter;

    private int score = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        
    }
    /// <summary>
    /// adds the score to the score counter
    /// </summary>
    /// <param name="amount"></param>
    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();

    }
    /// <summary>
    /// updates the score text to display the current score
    /// </summary>
    public void UpdateScoreText()
    {
        scoreCounter.text = "Score: " + score.ToString();
        endGameScoreCounter.text = "Score: " + score.ToString();

    }
}
