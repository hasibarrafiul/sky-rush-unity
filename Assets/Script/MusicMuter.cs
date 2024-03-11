using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicMuter : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioMixer mainMixer;
    public Button musicButton;
    public Button sfxButton;
    public Sprite muteSprite;
    public Sprite unmuteSprite;

    void Start()
    {
        float musicVolume = GetParameterValue("MusicVolume");
        float sfxVolume = GetParameterValue("SFXVolume");
        if(musicVolume == -80f){
            musicButton.image.sprite = muteSprite;
        }
        if(musicVolume != -80f){
            musicButton.image.sprite = unmuteSprite;
        }

        if(sfxVolume == -80f){
            sfxButton.image.sprite = muteSprite;
        }
        if(sfxVolume != -80f){
            sfxButton.image.sprite = unmuteSprite;
        }
        
    }

    public void MuteMusic()
    {
        float musicVolume = GetParameterValue("MusicVolume");
        if(musicVolume != -80f){
            mainMixer.SetFloat("MusicVolume", -80f); // -80dB is effectively muted
            PlayerPrefs.SetFloat("MusicVolume", -80f);
            musicButton.image.sprite = muteSprite;
        }
        else{
            mainMixer.SetFloat("MusicVolume", 0f); // 0dB is normal volume
            PlayerPrefs.SetFloat("MusicVolume", 0f);
            musicButton.image.sprite = unmuteSprite;
        }
    }

    public void MuteSFX()
    {
        float sfxVolume = GetParameterValue("SFXVolume");
        if(sfxVolume != -80f){
            mainMixer.SetFloat("SFXVolume", -80f); // -80dB is effectively muted
            PlayerPrefs.SetFloat("SFXVolume", -80f);
            sfxButton.image.sprite = muteSprite;
        }
        else{
            mainMixer.SetFloat("SFXVolume", 0f); // 0dB is normal volume
            PlayerPrefs.SetFloat("SFXVolume", 0f);
            sfxButton.image.sprite = unmuteSprite;
        }
    }

    public float GetParameterValue(string parameterName)
    {
        float value;
        mainMixer.GetFloat(parameterName, out value);
        return value;
    }

    public void BackToMainMenu()
    {
        //Debug.Log("Back to Main Menu");
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
