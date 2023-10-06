using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //To control if game is over or not (for relevant functions to be stopped/started)
    //public bool gameOver = true;

    //to be used for horizontal input of arrowkeys
    private float horizontalInput;
    public float speed;

    private float outOfRange = 19;

    private GameManager gameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        //Gets access to Game Manager script to access the isGameActive Variable
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (gameManagerScript.isGameActive)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        }
        //Hinders player to move out of bounds.
        //First if is for left boundary and the second one is for right.
        if (transform.position.x < -outOfRange)
        {
            transform.position = new Vector3(-outOfRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > outOfRange)
        {
            transform.position = new Vector3(outOfRange, transform.position.y, transform.position.z);
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
