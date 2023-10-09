using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveButchers : MonoBehaviour
{
    private GameManager gameManagerScript;

    public float butcherSpeed;
    private Rigidbody butcherRigidbody;
    private GameObject player;

    //Variables used for InvokeRepeating call to increase difficulty as game goes on
    private float repeatDelay = 5.0f;
    private float repeatRate = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        butcherSpeed = 10.0f;

        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();

        butcherRigidbody = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");

        //Starts function after delay and then repeat in accordance to repeatrate
        InvokeRepeating("IncreaseDifficulty", repeatDelay, repeatRate);
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

    //!!!!!!Här kanske du kan lägga in om du ville testa något med typ att det ska komma några knivar eller så?
    //Isåfall kanske en for loop med typ 5 repeats som då skickar ut 5 knivar eller något sånt?
    private void IncreaseDifficulty()
    {
        butcherSpeed += 1.0f;
    }

}
