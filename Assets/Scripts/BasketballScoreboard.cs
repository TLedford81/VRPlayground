using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasketballScoreboard : MonoBehaviour
{
    private float currentScore;
    private float highscore;
    public TextMesh scoreText, prevScoreText, highScoreText;
    public GameObject scoreboard;
    

    private void Update()
    {
        scoreText.text = "Score: " + currentScore;
        highScoreText.text = "High Score: " + PlayerPrefsManager.GetBBHighsScore();
    }

    public void ResetGame()
    {
        if (currentScore > 0)
        {
            prevScoreText.text = "Previous Score: " + currentScore;
        }
        foreach (GameObject ball in GameObject.FindGameObjectsWithTag("Basketball"))
        {
            Destroy(ball);
        }
        if (currentScore >= PlayerPrefsManager.GetBBHighsScore())
        {
            PlayerPrefsManager.SetBBHighScore(currentScore);
        }
        currentScore = 0;
    }

    public void enableScoreboard()
    {
        scoreboard.SetActive(true);
    }
    public void disableScoreboard()
    {
        scoreboard.SetActive(false);
    }

    public void AddScore(float score)
    {
        currentScore += score;
    }
}
