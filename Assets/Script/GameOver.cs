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
    public GameObject lifeOne;
    public GameObject lifeTwo;
    public GameObject lifeThree;
    private Image lifeOneSprite;
    private Image lifeTwoSprite;
    private Image lifeThreeSprite;
    public Sprite noLifeSprite;

    void OnCollisionEnter(Collision collision){
        lifeThreeSprite = lifeThree.GetComponent<Image>();
        lifeTwoSprite= lifeTwo.GetComponent<Image>();
        lifeOneSprite = lifeOne.GetComponent<Image>();
        
        if (collision.gameObject.CompareTag("Obstacles")){
            if(totalLife > 1)
            {
                GameObject explosionObject = transform.Find("Explosion").gameObject;
                PlayExplosion(explosionObject);
                playbombAudio();
                totalLife--;
                Destroy(collision.gameObject);
                //SetText("Total Life:" + totalLife.ToString());
                if(totalLife == 2)
                {
                    lifeThreeSprite.sprite = noLifeSprite;
                }
                if(totalLife == 1)
                {
                    lifeTwoSprite.sprite = noLifeSprite;
                }
                if(totalLife == 0)
                {
                    lifeOneSprite.sprite = noLifeSprite;
                }
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
    public void PlayExplosion(GameObject explosionObject)
    {
        // Find the "explosion" game object by name
        

        // Check if the "explosion" game object is found
        if (explosionObject != null)
        {
            // Find the Particle System component within the "smokyExplosion" child game object
            ParticleSystem explosionParticle = explosionObject.transform.Find("SmokeyExplosion").GetComponent<ParticleSystem>();

            // Check if the Particle System component is not null
            if (explosionParticle != null)
            {
                // Play the particle system
                explosionParticle.Play();
            }
            else
            {
                Debug.LogError("Particle system component not found in smokyExplosion.");
            }
        }
        else
        {
            Debug.LogError("Explosion game object not found.");
        }
    }
}
