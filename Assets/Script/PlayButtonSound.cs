using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButtonSound : MonoBehaviour
{
    public GameObject clickAudioObject;
    // Start is called before the first frame update
    public void playClick()
    {
        if (clickAudioObject != null)
            {
                AudioSource clickAudioSource = clickAudioObject.GetComponent<AudioSource>();

                if (clickAudioSource != null)
                {
                    clickAudioSource.Play();
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
}
