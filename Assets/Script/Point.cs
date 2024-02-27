using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Point : MonoBehaviour
{
    // Start is called before the first frame update

    private int point = 0;
    public Text textComponent;
    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Coin"))
        {
            Debug.Log("Coin Collected");
            point++;
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

}
