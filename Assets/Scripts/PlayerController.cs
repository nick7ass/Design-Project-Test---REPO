using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //Used for control of horizontal input of arrowkeys
    private float horizontalInput;

    //Controls speed of player
    public float playerSpeed;

    //Variable used to decide range in the X axis, used to make sure player dont go out of bounds
    private float outOfRangeX = 19;

    //gets the Game manager script to a access the isGameActive variable
    private GameManager gameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        //Getting the game manager script from gameobject Game Manager
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //As long as the isGameActive is true, gets horizontal input
        if (gameManagerScript.isGameActive)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * playerSpeed);
        }

        //Hinders player to move out of bounds.
        //First if-statement is for left boundary and the second one is for right.
        if (transform.position.x < -outOfRangeX)
        {
            transform.position = new Vector3(-outOfRangeX, transform.position.y, transform.position.z);
        }

        if (transform.position.x > outOfRangeX)
        {
            transform.position = new Vector3(outOfRangeX, transform.position.y, transform.position.z);
        }











        //Make noise when pressing space
        //if (Input.GetKeyDown(KeyCode.Space) && !gameOver)
        //{
        //Ist för denna så använd ljud
        //Instantiate(cookiePrefab, transform.position, transform.rotation);
        //}
    }

    //To make it so when the player collides with obstacle, game over
    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.CompareTag("Ground"))
        //{
        //    isOnGround = true;
        //    dirtParticle.Play();

        //}
        //else
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game over!");
            gameManagerScript.GameOver();
            //Death animation, first is to trigger it (set it to true) and then which death animation
            //playerAnim.SetBool("Death_b", true);
            //playerAnim.SetInteger("DeathType_int", 1);
            //explosionParticle.Play();
            //dirtParticle.Stop();
            //playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }
}
