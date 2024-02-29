using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : MonoBehaviour
{
    public float moveSpeed = 5f;

    
    void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        if(Time.timeScale != 0f){
            moveSpeed += 0.001f;
        }
        
        float rotationY = transform.rotation.eulerAngles.y;
        float rotationX = transform.rotation.eulerAngles.x;
        float rotationZ = transform.rotation.eulerAngles.z;
        if (rotationY != 0 || rotationX != 0 || rotationZ != 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
