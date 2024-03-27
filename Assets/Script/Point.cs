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
            GameObject sparkObject = transform.Find("Spark").gameObject;
            PlaySpark(sparkObject);
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

        public void PlaySpark(GameObject explosionObject)
        {
        // Find the "explosion" game object by name
        

        // Check if the "explosion" game object is found
        if (explosionObject != null)
        {
            // Find the Particle System component within the "smokyExplosion" child game object
            ParticleSystem explosionParticle = explosionObject.transform.Find("BasicSpark").GetComponent<ParticleSystem>();

            // Check if the Particle System component is not null
            if (explosionParticle != null)
            {
                // Play the particle system
                explosionParticle.Play();
            }
            else
            {
                Debug.LogError("Particle system component not found in BasicSpark.");
            }
        }
        else
        {
            Debug.LogError("BasicSpark game object not found.");
        }
    }
}
