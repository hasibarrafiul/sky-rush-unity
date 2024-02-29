using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicMuter : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioMixer mainMixer;

    public void MuteMusic()
    {
        float musicVolume = GetParameterValue("MusicVolume");
        if(musicVolume != -80f){
            mainMixer.SetFloat("MusicVolume", -80f); // -80dB is effectively muted
            PlayerPrefs.SetFloat("MusicVolume", -80f);
        }
        else{
            mainMixer.SetFloat("MusicVolume", 0f); // 0dB is normal volume
            PlayerPrefs.SetFloat("MusicVolume", 0f);
        }
    }

    public void MuteSFX()
    {
        float sfxVolume = GetParameterValue("SFXVolume");
        if(sfxVolume != -80f){
            mainMixer.SetFloat("SFXVolume", -80f); // -80dB is effectively muted
            PlayerPrefs.SetFloat("SFXVolume", -80f);
        }
        else{
            mainMixer.SetFloat("SFXVolume", 0f); // 0dB is normal volume
            PlayerPrefs.SetFloat("SFXVolume", 0f);
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
