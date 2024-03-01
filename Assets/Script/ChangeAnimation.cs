using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAnimation : MonoBehaviour
{

    public Animator animator;
    public RuntimeAnimatorController inAir;
    public RuntimeAnimatorController run;
    public GameObject runSoundGameObject;
    public GameObject airSoundGameObject;
    public bool isGrounded = false;

    void Awake()
    {
        animator.runtimeAnimatorController = inAir;
        playAirAudio();
    }
    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Ground"))
        {
            //Debug.Log("Trigger");
            stopAirAudio();
            playRunAudio();
            isGrounded = true;
            animator.runtimeAnimatorController = run;
        }
    }

    void OnCollisionExit(Collision collision){
        if (collision.gameObject.CompareTag("Ground"))
        {
            //Debug.Log("Trigger out");
            stopRunAudio();
            playAirAudio();
            isGrounded = false;
            animator.runtimeAnimatorController = inAir;
        }
    }

    void playRunAudio()
    {
        if (runSoundGameObject != null)
            {
                AudioSource runAudioSource = runSoundGameObject.GetComponent<AudioSource>();

                if (runAudioSource != null)
                {
                    runAudioSource.Play();
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

    void playAirAudio()
    {
        if (airSoundGameObject != null)
            {
                AudioSource airAudioSource = airSoundGameObject.GetComponent<AudioSource>();

                if (airAudioSource != null)
                {
                    airAudioSource.Play();
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
