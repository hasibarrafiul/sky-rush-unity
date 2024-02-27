using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighScoreHandler : MonoBehaviour
{
    
    public int HighScore;
    public Text HighScoreDisplayTextComponent;

    void Start()
    {
        HighScore = PlayerPrefs.GetInt("HighScore");
        if (HighScoreDisplayTextComponent != null)
        {
            // Set the text value
            HighScoreDisplayTextComponent.text = "High Score:" + HighScore.ToString();
        }
        else
        {
            Debug.LogError("Text component is not assigned!");
        }
    }

    public void ResetHighScore()
    {
        PlayerPrefs.SetInt("HighScore", 0);
        HighScore = 0;
        if (HighScoreDisplayTextComponent != null)
        {
            // Set the text value
            HighScoreDisplayTextComponent.text = "High Score:" + HighScore.ToString();
        }
        else
        {
            Debug.LogError("Text component is not assigned!");
        }
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
