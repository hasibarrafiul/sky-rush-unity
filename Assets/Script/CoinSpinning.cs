using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpinning : MonoBehaviour
{
    public float spinSpeed = 100f;

    void Update()
    {
        transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
    }
}
