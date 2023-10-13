using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject butcher;
    //public Vector3 spawnPos;
    public float startDelay;
    public float repeatRate;
    private float spawnPosZ = 125;
    private float spawnPosY = 0.0f;
    private float spawnPosRangeX = 20.0f;
    private GameManager gameManagerScript;

    //Variable for Audio
    private AudioSource butcherAudio;
    public AudioClip butcherScreamOne;
    public AudioClip butcherScreamTwo;


    public void StartSpawningButchers()
    {
        butcherAudio = GetComponent<AudioSource>();
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
        InvokeRepeating("SpawnButcher", startDelay, repeatRate);
    }

    private void SpawnButcher()
    {
        if (gameManagerScript.isGameActive)
        {
            butcherAudio.PlayOneShot(butcherScreamOne, 1.0f);
            Instantiate(butcher, getRandomSpawnPos(), butcher.transform.rotation);
            //butcherAudio.PlayOneShot(butcherScreamTwo, 1.0f);
        }
    }

    private Vector3 getRandomSpawnPos()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnPosRangeX, spawnPosRangeX), spawnPosY, spawnPosZ);
        return spawnPos;
    }

}
