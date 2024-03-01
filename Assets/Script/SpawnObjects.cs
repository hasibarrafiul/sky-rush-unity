using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    
    public GameObject obsPrefab;
    public GameObject coinPrefabs;
    private Vector3 spawnPosition;
    private Vector3 coinPosition;
    void Start()
    {
        //spawn 5 obstacles
        int[] zSpawnObs = new int[5];
        for(int i = 0; i < 3; i++)
        {
            int xSpawnObs = Random.Range(Mathf.RoundToInt(transform.position.x-1), Mathf.RoundToInt(transform.position.x+2));
            int ySpawnObs = (int)transform.position.y+1;
            zSpawnObs[i] = (int)Random.Range(transform.position.z+10, transform.position.z);
            if(i>0){
                recheck:
                for(int j = i-1; j >= 0; j--){
                    if(zSpawnObs[i] == zSpawnObs[j]){
                    zSpawnObs[i] = (int)Random.Range(transform.position.z+10, transform.position.z);
                    goto recheck;
                    }
                } 
            }
            spawnPosition = new Vector3(xSpawnObs, ySpawnObs, zSpawnObs[i]);
            SpawnObstacles();
        }

        int[] zSpawnCoin = new int[5];
        for(int i = 0; i < 3; i++)
        {
            int xSpawnCoin = Random.Range(Mathf.RoundToInt(transform.position.x-1), Mathf.RoundToInt(transform.position.x+2));
            int ySpawnCoin = (int)transform.position.y+1;
            zSpawnCoin[i] = (int)Random.Range(transform.position.z+10, transform.position.z);
            recheck3:
            for(int j = 0; j < 5; j++){
                if(zSpawnCoin[i] == zSpawnObs[j]){
                    zSpawnCoin[i] = (int)Random.Range(transform.position.z+10, transform.position.z);
                    goto recheck3;
                }
                
            }
            if(i>0){
                recheck2:
                for(int j = i-1; j >= 0; j--){
                    if(zSpawnCoin[i] == zSpawnCoin[j]){
                    zSpawnCoin[i] = (int)Random.Range(transform.position.z+10, transform.position.z-8);
                    goto recheck2;
                    }
                } 
            }
            coinPosition = new Vector3(xSpawnCoin, ySpawnCoin, zSpawnCoin[i]);
            SpawnCoins();
        }

    }

    void SpawnObstacles()
    {
        if (obsPrefab != null)
        {
            GameObject newMesh = Instantiate(obsPrefab, spawnPosition, Quaternion.identity);
            // You can add additional customization here if needed
        }
        else
        {
            Debug.LogError("Mesh prefab is not assigned!");
        }
    }
    
    void SpawnCoins()
    {
        if (coinPrefabs != null)
        {
            GameObject newMesh = Instantiate(coinPrefabs, coinPosition, Quaternion.identity);
            // You can add additional customization here if needed
        }
        else
        {
            Debug.LogError("Mesh prefab is not assigned!");
        }
    }

    
}
