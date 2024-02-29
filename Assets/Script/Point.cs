using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Point : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject coinAudioObject;
    private int point = 0;
    public Text textComponent;

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Coin"))
        {
            //Debug.Log("Coin Collected");
            point++;
            playCoinAudio();
            if(PlayerPrefs.GetInt("HighScore") < point)
            {
                PlayerPrefs.SetInt("HighScore", point);
            }
            SetText(point.ToString());
            Destroy(collision.gameObject);
            //Destroy(collision.gameObject);
        }
    }

    public void SetText(string value)
    {
        // Check if the text component is assigned
        if (textComponent != null)
        {
            // Set the text value
            textComponent.text = value;
        }
        else
        {
            Debug.LogError("Text component is not assigned!");
        }
    }

    void playCoinAudio()
    {
        if (coinAudioObject != null)
            {
                AudioSource coinAudioSource = coinAudioObject.GetComponent<AudioSource>();

                if (coinAudioSource != null)
                {
                    coinAudioSource.Play();
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
