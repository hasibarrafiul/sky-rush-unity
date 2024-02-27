using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    public int totalLife = 3;
    private bool isPaused = false;
    public Canvas gameOverCanvas;
    public Text TotalLifetextComponent;


    void onAwake()
    {
        
        if (TotalLifetextComponent != null)
        {
            // Set the text value
            TotalLifetextComponent.text = "Total Life:" + totalLife.ToString();
        }
        else
        {
            Debug.LogError("Text component is not assigned!");
        }
        //SetText("Total Life:" + totalLife.ToString());
    }

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Obstacles"))
        {
            if(totalLife > 1)
            {
                totalLife--;
                Destroy(collision.gameObject);
                SetText("Total Life:" + totalLife.ToString());

                //Debug.Log("Life: " + totalLife);
            }
            else
            {
                SetGameOver();
            }
            //SetGameOver();
        }

        if (collision.gameObject.CompareTag("Fall"))
        {
            SetGameOver();
        }
    }

    public void SetGameOver()
    {
        TogglePause();
        disableMovement();
        gameOverCanvas.gameObject.SetActive(true);
    }

    void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            // Pause the game
            Time.timeScale = 0f;
            
        }
        else
        {
            // Unpause the game
            Time.timeScale = 1f;
        }
    }

    public void OnRestartButtonClick(){
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        
        // Reload the current scene
        SceneManager.LoadScene(currentSceneIndex);
        gameOverCanvas.gameObject.SetActive(true);
        enableMovement();
        TogglePause();

    }

    public void SetText(string value)
    {
        // Check if the text component is assigned
        if (TotalLifetextComponent != null)
        {
            // Set the text value
            TotalLifetextComponent.text = value;
        }
        else
        {
            Debug.LogError("Text component is not assigned!");
        }
    }

    public void OnMainMenuButtonClick()
    {
        TogglePause();
        SceneManager.LoadScene("MainMenu");
        
    }

    public void disableMovement()
    {
        Movement movementComponent = GetComponent<Movement>();
        if (movementComponent != null)
        {
            // Disable the Script2 component
            movementComponent.enabled = false;
        }
        else
        {
            Debug.LogWarning("Script component not found!");
        }
    }

    public void enableMovement()
    {
        Movement movementComponent = GetComponent<Movement>();
        if (movementComponent != null)
        {
            // Enable the Script2 component
            movementComponent.enabled = true;
        }
        else
        {
            Debug.LogWarning("Script component not found!");
        }
    }


}
