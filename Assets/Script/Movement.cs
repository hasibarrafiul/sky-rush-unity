using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Movement : MonoBehaviour
{
    
    private bool isPaused = false;
    public Canvas pauseCanvas;
    private Vector2 fingerDownPosition;
    private Vector2 fingerUpPosition;
    private bool swipeDetected = false;

    public bool detectSwipeOnlyAfterRelease = false;
    public float minDistanceForSwipe = 20f;
    public Button button;
    public GameObject switchLaneAudioObject;
    public GameObject runSoundGameObject;
    public GameObject airSoundGameObject;
    public AudioClip mainMenuAudioClip;
    
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                fingerDownPosition = touch.position;
                fingerUpPosition = touch.position;
                swipeDetected = false;
            }

            if (!detectSwipeOnlyAfterRelease && touch.phase == TouchPhase.Moved)
            {
                fingerUpPosition = touch.position;
                DetectSwipe();
            }

            if (touch.phase == TouchPhase.Ended)
            {
                fingerUpPosition = touch.position;
                DetectSwipe();
            }
        }


        if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)){
            if(!isPaused){
                playSwitchLaneAudio();
                transform.position += new Vector3(-1,0,0);
            }
        }
        if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)){
            if(!isPaused){
                playSwitchLaneAudio();
                transform.position += new Vector3(1,0,0);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SetGamePause();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(!isPaused){
                ChangeAnimation groundCheck = FindObjectOfType<ChangeAnimation>();
                bool isGrounded = groundCheck.isGrounded;
                if(isGrounded){
                    playSwitchLaneAudio();
                    transform.position += new Vector3(0,2,0);
                }
            }
        }
    }

     public void SetGamePause()
    {
        stopAirAudio();
        stopRunAudio();
        TogglePause();
        button.gameObject.SetActive(!button.gameObject.activeSelf);
        
    }

    public void setGameResume(){
        TogglePause();
        button.gameObject.SetActive(!button.gameObject.activeSelf);
        
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
        AudioManager.instance.PlayAudio(mainMenuAudioClip);
        SceneManager.LoadScene("MainMenu");
        TogglePause();
    }

    void DetectSwipe()
    {
        if (!swipeDetected && Vector3.Distance(fingerDownPosition, fingerUpPosition) >= minDistanceForSwipe)
        {
            Vector2 direction = fingerUpPosition - fingerDownPosition;

            // Calculate absolute values for direction components
            float absX = Mathf.Abs(direction.x);
            float absY = Mathf.Abs(direction.y);

            if (absX > absY)
            {
                // Horizontal swipe
                if (direction.x > 0) // Right swipe
                {
                    Debug.Log("Right Swipe Detected!");
                    swipeDetected = true;
                    if (!isPaused)
                    {
                        playSwitchLaneAudio();
                        transform.position += new Vector3(1, 0, 0);
                    }
                }
                else // Left swipe
                {
                    Debug.Log("Left Swipe Detected!");
                    swipeDetected = true;
                    if (!isPaused)
                    {
                        playSwitchLaneAudio();
                        transform.position += new Vector3(-1, 0, 0);
                    }
                }
            }
            else
            {
                // Vertical swipe
                if (direction.y > 0) // Up swipe
                {
                    Debug.Log("Up Swipe Detected!");
                    swipeDetected = true;
                    if(!isPaused){
                        ChangeAnimation groundCheck = FindObjectOfType<ChangeAnimation>();
                        bool isGrounded = groundCheck.isGrounded;
                        if(isGrounded){
                            playSwitchLaneAudio();
                            transform.position += new Vector3(0,2,0);
                        }
                    }
                }
                else // Down swipe
                {
                    Debug.Log("Down Swipe Detected!");
                    swipeDetected = true;
                    // Perform actions for swipe down
                }
            }
        }

    }

    void playSwitchLaneAudio()
        {
        if (switchLaneAudioObject != null)
            {
                AudioSource switchLaneAudioSource = switchLaneAudioObject.GetComponent<AudioSource>();

                if (switchLaneAudioSource != null)
                {
                    switchLaneAudioSource.Play();
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
