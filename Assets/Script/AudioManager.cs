using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource audioSource;

    // Ensure only one instance of AudioManager exists
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Prevents the GameObject from being destroyed when loading a new scene
            audioSource = GetComponent<AudioSource>(); // Get the AudioSource component
        }
        else
        {
            Destroy(gameObject); // If an instance already exists, destroy this one
        }
    }

    // Play the specified AudioClip
    public void PlayAudio(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }

    // Stop the currently playing audio
    public void StopAudio()
    {
        audioSource.Stop();
    }
}