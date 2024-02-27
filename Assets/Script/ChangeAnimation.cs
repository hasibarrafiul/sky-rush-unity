using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAnimation : MonoBehaviour
{

    public Animator animator;
    public RuntimeAnimatorController inAir;
    public RuntimeAnimatorController run;

    void Awake()
    {
        animator.runtimeAnimatorController = inAir;
    }
    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Ground"))
        {
            //Debug.Log("Trigger");
            animator.runtimeAnimatorController = run;
        }
    }

    void OnCollisionExit(Collision collision){
        if (collision.gameObject.CompareTag("Ground"))
        {
            //Debug.Log("Trigger out");
            animator.runtimeAnimatorController = inAir;
        }
    }
}
