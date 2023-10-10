using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveButchers : MonoBehaviour
{
    private GameManager gameManagerScript;

    public float butcherSpeed;
    private Rigidbody butcherRigidbody;
    private GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();

        butcherSpeed = gameManagerScript.obstacleSpeed;

        butcherRigidbody = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {
        if (gameManagerScript.isGameActive)
        {
            Vector3 butcherDirection = (player.transform.position - transform.position).normalized;
            butcherRigidbody.AddForce(butcherDirection * butcherSpeed);
        }

        if (butcherRigidbody.position.z < 2)
        {
            Destroy(gameObject);
        }
    }

}
