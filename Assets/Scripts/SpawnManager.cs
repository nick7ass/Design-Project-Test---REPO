using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject butcher;
    //public Vector3 spawnPos;
    public float startDelay = 1.0f;
    public float repeatRate = 5.0f;
    private float spawnPosZ = 125;
    private float spawnPosY = 0.0f;
    private float spawnPosRangeX = 20.0f;
    private GameManager gameManagerScript;


    public void StartSpawningButchers()
    {
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
        InvokeRepeating("SpawnButcher", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnButcher()
    {
        if (gameManagerScript.isGameActive)
        {
            Instantiate(butcher, getRandomSpawnPos(), butcher.transform.rotation);
            
        }
    }

    private Vector3 getRandomSpawnPos()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnPosRangeX, spawnPosRangeX), spawnPosY, spawnPosZ);
        return spawnPos;
    }

}
