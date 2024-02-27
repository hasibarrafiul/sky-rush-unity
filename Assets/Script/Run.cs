using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : MonoBehaviour
{
    public float moveSpeed = 5f;

    
    void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        moveSpeed += 0.001f;
        
        
        float rotationY = transform.rotation.eulerAngles.y;
        if (rotationY != 0)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0, transform.rotation.eulerAngles.z);
        }
    }
}
