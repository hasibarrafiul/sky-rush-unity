using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartTheGame()
    {
        SceneManager.LoadScene("LoadingScene");
    }

    public void ExitGame()
    {
        //Debug.Log("Exiting the game...");
        Application.Quit(); 
    }

    public void GoToHighScore()
    {
        SceneManager.LoadScene("HighScore");
    }
}
