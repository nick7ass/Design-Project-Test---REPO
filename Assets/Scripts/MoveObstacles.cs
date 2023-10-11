using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacles : MonoBehaviour
{
    private GameManager gameManagerScript;

    private float obstacleSpeed;
    
    private Rigidbody obstacleRigidbody;

    

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();

        obstacleSpeed = gameManagerScript.obstacleSpeed;

        obstacleRigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (gameManagerScript.isGameActive)
        {
            Vector3 obstacleDirection = new Vector3(Random.Range(-3, 3), 0, -20).normalized;

            if (obstacleRigidbody.CompareTag("Obstacle"))
            {
                obstacleRigidbody.AddForce(obstacleDirection * obstacleSpeed, ForceMode.Impulse);
            } else if (obstacleRigidbody.CompareTag("Powerup")) {
                obstacleRigidbody.AddForce(obstacleDirection * obstacleSpeed/2);
            }
        }

        if (obstacleRigidbody.position.z < 2)
        {
            Destroy(gameObject);
        }
    }

}
