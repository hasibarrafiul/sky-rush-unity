using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGround : MonoBehaviour
{
    public GameObject groundPrefab;
    public GameObject spawnMoreGround;
    public GameObject infinity;
    public Vector3 spawnPosition;
    public Vector3 spawnMorePosition;
    public Vector3 spawnInfinityPosition;
    public int x = 0;
    public int y = 60;
    public int z = 10;
    private int handleSpeed = 0;
    

    void Start()
    {
        wave();
        AudioManager.instance.StopAudio();
    }

    void wave(){
        spawnPosition = new Vector3(x, y, z);
        spawnGround();
        for(int i = 1; i < 5; i++)
        {
            int[] randomX = {x, (x+2), (x-2)};
            int randomIndex = UnityEngine.Random.Range(0, randomX.Length);
            int selectedX = randomX[randomIndex];
            //x = Mathf.RoundToInt(Random.Range(-3, 4));
            y -= 5;
            z += 20+handleSpeed;
            spawnPosition = new Vector3(selectedX, y, z);
            spawnGround();
            handleSpeed ++;
            if(i == 4){
                spawnMorePosition = new Vector3(selectedX, y+1, z);
                infinity.transform.position = new Vector3(selectedX, y-10, z);
                spawnMoreGroundTrigger();
            }
        }
    }

    void spawnGround()
    {
        if (groundPrefab != null)
        {
            GameObject newMesh = Instantiate(groundPrefab, spawnPosition, Quaternion.identity);
            // You can add additional customization here if needed
        }
        else
        {
            Debug.LogError("Mesh prefab is not assigned!");
        }
    }

    void spawnMoreGroundTrigger()
    {
        if (groundPrefab != null)
        {
            GameObject newMesh = Instantiate(spawnMoreGround, spawnMorePosition, Quaternion.identity);
            // You can add additional customization here if needed
        }
        else
        {
            Debug.LogError("Mesh prefab is not assigned!");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("SpawnMore"))
        {
            y -= 5;
            z += 25+handleSpeed;
            wave();
        }
    }

}
