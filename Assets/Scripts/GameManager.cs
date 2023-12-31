using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Declare/create list to place obstacle prefabs in for use in game.
    public List<GameObject> obstacles;

    //Variable for score text & Game over text (aka UI text to be or appear on screen
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;

    //Used to access the buttons and title in ui
    public GameObject titleScreen;

    public GameObject gameOverScreen;

    public GameObject powerup;

    public SpawnManager spawnManagerScript;

    //Var for storing the score
    private int score;

    //Var for spawnRate
    private float spawnRate = 3.0f;

    private float spawnPosZ = 125.0f;
    private float spawnPosY  = 5.0f;
    private float spawnPosRangeX = 20.0f;

    //Variables used for InvokeRepeating call to increase difficulty as game goes on
    //and variable to hold the speed to be increased
    private float repeatDelay = 4.0f;
    private float repeatRate = 3.0f;
    public float obstacleSpeed;

    public bool isGameActive;

    public GameObject player;
    public GameObject playerCorpse;

    //Variable for particle effects
    public ParticleSystem redExplosionParticle;
    public ParticleSystem dirtSplatterParticle;

    //Variable for Audio
    private AudioSource gameOverAudio;
    public AudioClip gameOverScream;


    // Start is called before the first frame update
    void Start()
    {
        spawnManagerScript = spawnManagerScript.GetComponent<SpawnManager>();

        gameOverAudio = GetComponent<AudioSource>();

        //playerControllerScript = playerControllerScript.GetComponent<PlayerController>();

        //Controls speed of obstacles (Both butchers and boulders etc, plus the world in move world script.
        obstacleSpeed = 8.0f;
    }

    public void StartGame()
    {
        //Sets player to active
        player.SetActive(true);

        //Variable to control if game is active
        isGameActive = true;

        //Makes it so the start button and title text disappers when game starts
        titleScreen.SetActive(false);

        //Sets starting score to 0
        score = 0;

        //Starts particles
        dirtSplatterParticle.Play();

        //Starts the spawn of butchers
        spawnManagerScript.StartSpawningButchers();

        //Starts spawning obstacles
        StartCoroutine(SpawnObstacles());

        //Updates and displays score
        StartCoroutine(UpdateScore());

        //Starts function after delay and then repeat in accordance to repeatrate
        InvokeRepeating("IncreaseDifficulty", repeatDelay, repeatRate);

        InvokeRepeating("SpawnPowerup", repeatDelay, repeatRate * repeatDelay);

    }

    //Function that makes it so that obstacles are spawned while isGameActive variable is true.
    //Game over (collision with obstacle) would therefor make this loop stop
    IEnumerator SpawnObstacles()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, obstacles.Count);
            Instantiate(obstacles[index], getRandomSpawnPosition(), obstacles[index].transform.rotation);
            UpdateSpawnRate();

            if (score>300)
            {
                index = Random.Range(0, obstacles.Count);
                Instantiate(obstacles[index], getRandomSpawnPosition(), obstacles[index].transform.rotation);
            }
            if (score > 800)
            {
                index = Random.Range(0, obstacles.Count);
                Instantiate(obstacles[index], getRandomSpawnPosition(), obstacles[index].transform.rotation);
            }
        }
    }

    //Method to update and show the score, updating for as long as the isGameActive variable is true.
    IEnumerator UpdateScore()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(1);
            //Adds 10 to score
            score += 10;

            //Displaying the score 
            scoreText.text = "Score: " + score;
        }
    }

    //Increases the difficulty over time by adjusting the spawnrate of obstacles 
    void UpdateSpawnRate()
    {
        if (spawnRate>1.0f)
        {
            spawnRate -= 0.1f;
        }
    }

    //Increases the speed of obstacles on a repeat with selected delay and repeatrate from InvokeRepeating in StartGame
    private void IncreaseDifficulty()
    {
        obstacleSpeed += 1.0f;
    }

    //Function to spawn Powerups
    private void SpawnPowerup()
    {
        Instantiate(powerup, new Vector3(Random.Range(-spawnPosRangeX, spawnPosRangeX), spawnPosY/2, spawnPosZ), powerup.transform.rotation);
    }


    //Used to get a random spawn position for obstacle
    private Vector3 getRandomSpawnPosition()
    {
        //Getting random numbers for spawn position in X
        float spawnPosX = Random.Range(-spawnPosRangeX, spawnPosRangeX);

        //Variable to clean up in instantiate
        Vector3 randomPos = new Vector3(spawnPosX, spawnPosY, spawnPosZ);
        return randomPos;
    }

    //Triggered by player colliding with an obstacle.
    public void GameOver()
    {
        gameOverAudio.PlayOneShot(gameOverScream, 1.0f);
        dirtSplatterParticle.Stop();
        playerCorpse.transform.Translate(player.transform.position.x, 0, 0);
        playerCorpse.SetActive(true);
        redExplosionParticle.Play();
        player.SetActive(false);

        gameOverScreen.SetActive(true);

        isGameActive = false;

    }

    //function to restart the game (used by clicking on the gameover button restart game)
    public void RestartGame()
    {
        //Den första delen är the actual code o sen i parantes e liksom name of scene,
        //så där kan man skriva scen-namnet. This takes the current scenes name and loads.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
