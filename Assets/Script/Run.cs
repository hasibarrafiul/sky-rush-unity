using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : MonoBehaviour
{
    public float moveSpeed = 5f;
    void Start()
    {
        StartRepeating();
    }
    
    void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        float rotationY = transform.rotation.eulerAngles.y;
        float rotationX = transform.rotation.eulerAngles.x;
        float rotationZ = transform.rotation.eulerAngles.z;
        if (rotationY != 0 || rotationX != 0 || rotationZ != 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        Vector3 currentPosition = transform.position;

        // Round position to the nearest integer
        Vector3 roundedPosition = RoundToNearestInteger(currentPosition);

        // Set the rounded position back to the character
        transform.position = roundedPosition;
    }
    
    public void StartRepeating()
    {
        // Call MyFunction every 1 second
        InvokeRepeating("increaseMoveSpeed", 1f, 1f);
    }
    public void StopRepeating()
    {
        // Stop invoking MyFunction
        CancelInvoke("increaseMoveSpeed");
    }
    void increaseMoveSpeed()
    {
        moveSpeed += 0.3f;
    }

    Vector3 RoundToNearestInteger(Vector3 position)
    {
        // Round each component of the position to the nearest integer
        float roundedX = Mathf.Round(position.x);
        float roundedY = position.y;
        float roundedZ = position.z;

        // Return the rounded position
        return new Vector3(roundedX, roundedY, roundedZ);
    }   
}
