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
    public Button button;
    public GameObject bombAudioObject;
    public GameObject GameOverAudioObject;
    public GameObject runSoundGameObject;
    public GameObject airSoundGameObject;
    public AudioClip mainMenuAudioClip;


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
                playbombAudio();
                totalLife--;
                Destroy(collision.gameObject);
                SetText("Total Life:" + totalLife.ToString());

                //Debug.Log("Life: " + totalLife);
            }
            else
            {
                stopRunAudio();
                stopAirAudio();
                playGameOverAudio();
                SetGameOver();
            }
            //SetGameOver();
        }

        if (collision.gameObject.CompareTag("Fall"))
        {
            stopRunAudio();
            stopAirAudio();
            playGameOverAudio();
            SetGameOver();
        }
    }

    public void SetGameOver()
    {
        TogglePause();
        Run toggleRunSpeed = FindObjectOfType<Run>();
        toggleRunSpeed.StopRepeating();
        disableMovement();
        button.gameObject.SetActive(!button.gameObject.activeSelf);
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
        button.gameObject.SetActive(!button.gameObject.activeSelf);

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
        AudioManager.instance.PlayAudio(mainMenuAudioClip);
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

    void playbombAudio()
    {
        if (bombAudioObject != null)
            {
                AudioSource bombAudioSource = bombAudioObject.GetComponent<AudioSource>();

                if (bombAudioSource != null)
                {
                    bombAudioSource.Play();
                }
                else
                {
                    Debug.LogWarning("AudioSource component not found on the coin object.");
                }
            }
            else
            {
                Debug.LogWarning("Coin object not found.");
            }
        }

        void playGameOverAudio()
        {
        if (GameOverAudioObject != null)
            {
                AudioSource gameOverAudioSource = GameOverAudioObject.GetComponent<AudioSource>();

                if (gameOverAudioSource != null)
                {
                    gameOverAudioSource.Play();
                }
                else
                {
                    Debug.LogWarning("AudioSource component not found on the Game over object.");
                }
            }
            else
            {
                Debug.LogWarning("Coin object not found.");
            }
        }

        void stopRunAudio()
        {
            if (runSoundGameObject != null)
            {
                AudioSource runAudioSource = runSoundGameObject.GetComponent<AudioSource>();

                if (runAudioSource != null)
                {
                    runAudioSource.Stop();
                }
                else
                {
                    Debug.LogWarning("AudioSource component not found on the Game object.");
                }
            }
            else
            {
                Debug.LogWarning("object not found.");
            }
        }

        void stopAirAudio()
        {
            if (airSoundGameObject != null)
            {
                AudioSource airAudioSource = airSoundGameObject.GetComponent<AudioSource>();

                if (airAudioSource != null)
                {
                    airAudioSource.Stop();
                }
                else
                {
                    Debug.LogWarning("AudioSource component not found on the Game object.");
                }
            }
            else
            {
                Debug.LogWarning("object not found.");
            }
        }

}
