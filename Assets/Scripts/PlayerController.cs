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

    //Variable for scale during powerup, variable for adjusting scale and variable for controlling whether powered up or not
    Vector3 powerupScaleChange;
    int scaleChange = 3;
    bool hasActivePowerup;
    private Animator playerAnimator;

    //Variable for particle effects
    public ParticleSystem greyExplosionParticle;

    //Variables for sound
    public AudioClip crashSound;
    private AudioSource playerAudio;


    // Start is called before the first frame update
    void Start()
    {
        //Getting the game manager script from gameobject Game Manager
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
        playerAnimator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

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

        //Stops the player from moving out of bounds.
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
        //if (Input.GetKeyDown(KeyCode.Space) && !isGameActive)
        //{
        //Ist för denna så använd ljud
        //Instantiate(cookiePrefab, transform.position, transform.rotation);
        //}
    }

    //To make it so when the player collides with obstacle, game over
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") && !hasActivePowerup)
        {
            gameManagerScript.GameOver();
            
            //playerAudio.PlayOneShot(crashSound, 1.0f);
        }
        else if (collision.gameObject.CompareTag("Obstacle") && hasActivePowerup)
        {
            //Plays particle explosion when colliding with object and destroys object
            greyExplosionParticle.Play();
            Destroy(collision.gameObject);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasActivePowerup = true;
            Destroy(other.gameObject);
            powerupScaleChange = transform.localScale * scaleChange;
            transform.localScale = powerupScaleChange;
            playerAnimator.SetFloat("Speed_f", 1.9f);
            playerAnimator.SetBool("Eat_b", true);
            
            StartCoroutine(PowerupCountdownRoutine());
        } 
    }

    //A timer set to 8 seconds making it so that the powerup only stays active for 8 seconds then turns false
    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(8);
        playerAnimator.SetFloat("Speed_f", 2.0f);
        playerAnimator.SetBool("Eat_b", false);
        powerupScaleChange = transform.localScale / scaleChange;
        transform.localScale = powerupScaleChange;
        hasActivePowerup = false;
    }
}
