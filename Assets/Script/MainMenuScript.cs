using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioMixer mainMixer;
    void Start() {
        if(!PlayerPrefs.HasKey("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", 0);
        }
        if(!PlayerPrefs.HasKey("MusicVolume"))
        {
            PlayerPrefs.SetFloat("MusicVolume", -80f);
        }
        if(!PlayerPrefs.HasKey("SFXVolume"))
        {
            PlayerPrefs.SetFloat("SFXVolume", -80f);
        }

        if(PlayerPrefs.HasKey("MusicVolume")){
            mainMixer.SetFloat("MusicVolume", PlayerPrefs.GetFloat("MusicVolume"));
        }
        if(PlayerPrefs.HasKey("SFXVolume")){
            mainMixer.SetFloat("SFXVolume", PlayerPrefs.GetFloat("SFXVolume"));
        }
    }
    public void StartTheGame()
    {
        SceneManager.LoadScene("LoadingScene");
    }

    public void ExitGame()
    {
        //Debug.Log("Exiting the game...");
        Application.Quit(); 
    }

    public void GoToHighScore()
    {
        SceneManager.LoadScene("HighScore");
    }

    public void GoToAudioController()
    {
        SceneManager.LoadScene("AudioController");
    }
}
