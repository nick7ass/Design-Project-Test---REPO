using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacles : MonoBehaviour
{
    private GameManager gameManagerScript;

    public float obstacleSpeed;
    private Rigidbody obstacleRigidbody;

    //Variables used for InvokeRepeating call to increase difficulty as game goes on
    private float repeatDelay = 5.0f;
    private float repeatRate = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        obstacleSpeed = 8.0f;

        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();

        obstacleRigidbody = GetComponent<Rigidbody>();

        //Starts function after delay and then repeat in accordance to repeatrate
        InvokeRepeating("IncreaseDifficulty", repeatDelay, repeatRate);
       
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManagerScript.isGameActive)
        {
            Vector3 obstacleDirection = new Vector3(Random.Range(-3,3), 0, -20).normalized;
            obstacleRigidbody.AddForce(obstacleDirection * obstacleSpeed, ForceMode.Impulse);
        }

        if (obstacleRigidbody.position.z < 2)
        {
            Destroy(gameObject);
        }
    }

    private void IncreaseDifficulty()
    {
        obstacleSpeed += 1.0f;
    }
}
