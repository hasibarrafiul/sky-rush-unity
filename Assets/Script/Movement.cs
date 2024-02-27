using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Movement : MonoBehaviour
{
    
    private bool isPaused = false;
    public Canvas pauseCanvas;
    
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)){
            if(!isPaused){
            transform.position += new Vector3(-1,0,0);
            }
        }
        if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)){
            if(!isPaused){
                transform.position += new Vector3(1,0,0);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SetGamePause();
        }
    }

     public void SetGamePause()
    {
        TogglePause();
        
    }

    public void setGameResume(){
        TogglePause();
        
    }

     void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f;
            pauseCanvas.gameObject.SetActive(true);
            
        }
        else
        {
            Time.timeScale = 1f;
            pauseCanvas.gameObject.SetActive(false);
        }
    }

    public void restartGame()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        TogglePause();

    }

    public void backToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        TogglePause();
    }
}
