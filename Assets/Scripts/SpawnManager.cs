using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> obstacleTrees;
    //public Vector3 spawnPos;
    public float startDelay = 2.0f;
    public float repeatRate = 2.0f;
    private float spawnPosZ = 170;
    private float spawnPosRangeX = 20;
    private GameManager gameManager;


    public void StartSpawningTrees()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        InvokeRepeating("SpawnTreeObstacle", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnTreeObstacle()
    {
        if (gameManager.isGameActive == true)
        {
            int index = Random.Range(0, obstacleTrees.Count);
            Instantiate(obstacleTrees[index], getRandomSpawnPos(), obstacleTrees[index].transform.rotation);
        }
    }

    public Vector3 getRandomSpawnPos()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnPosRangeX, spawnPosRangeX), 0, spawnPosZ);
        return spawnPos;
    }

}
