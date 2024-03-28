using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public float destroyDelay = 60f; // Time delay before destroying the object

    void Start()
    {
        // Invoke the DestroyObject function after 'destroyDelay' seconds
        Invoke("DestroyObject", destroyDelay);
    }

    void DestroyObject()
    {
        // Destroy the GameObject this script is attached to
        Destroy(gameObject);
    }
}
