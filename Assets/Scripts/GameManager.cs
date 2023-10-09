using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Declare/create list. Similar to an array but not quite the same.
    //HÄR FÖR OBSTACLES
    public List<GameObject> obstacles;

    //Var for score / Game over text (aka UI text to be or appear on screen.
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;

    public Button restartButton;

    //Used to access the buttons and title in ui
    public GameObject titleScreen;

    public MoveWorld moveWorldScript;

    public SpawnManager spawnManagerScript;

    //Var for storing the score
    private int score;

    //Var for spawnRate
    private float spawnRate = 3.0f;

    private float spawnPosZ = 125.0f;
    private float spawnPosY  = 5.0f;
    private float spawnPosRangeX = 20.0f;

    public bool isGameActive;

    // Start is called before the first frame update
    void Start()
    {
        moveWorldScript = GameObject.Find("Environment").GetComponent<MoveWorld>();
        spawnManagerScript = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
    }

    public void StartGame()
    {
        //Variable to control if game is active
        isGameActive = true;

        Debug.Log("I clicked on start");

        //Makes it so the start button and title text disappers when game starts
        titleScreen.SetActive(false);

        score = 0;

        //Starts the spawn of butchers
        spawnManagerScript.StartSpawningButchers();

        //Starts spawning obstacles
        StartCoroutine(SpawnObstacles());

        //Updates and displays score
        StartCoroutine(UpdateScore());

    }

    IEnumerator SpawnObstacles()
    {
        //The isGameActive variable we define as true in start, but false in Game over function, which is
        //why this works to make it stop spawning things when gameover
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, obstacles.Count);
            Instantiate(obstacles[index], getRandomSpawnPosition(), obstacles[index].transform.rotation);
            UpdateSpawnRate();
            moveWorldScript.speed += 0.2f;
            
        }
    }

    //Method to update and show the score.
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

    void UpdateSpawnRate()
    {
        if (spawnRate>1.0f)
        {
            spawnRate -= 0.2f;
        }
    }

    private Vector3 getRandomSpawnPosition()
    {
        //Getting random numbers for spawn position in X
        float spawnPosX = Random.Range(-spawnPosRangeX, spawnPosRangeX);

        //Variable to clean up in instantiate
        Vector3 randomPos = new Vector3(spawnPosX, spawnPosY, spawnPosZ);
        return randomPos;
    }

    public void GameOver()
    {
        //make try again button appear:
        restartButton.gameObject.SetActive(true);
        //make game over text appear:
        gameOverText.gameObject.SetActive(true);
        //Used to maked diff functions etc not work.
        isGameActive = false;

    }

    //function to restart the game (used by gameober button restart game
    public void RestartGame()
    {
        //Den första delen är the actual code o sen i parantes e liksom name of scene,
        //så där kan man skriva scen-namnet. This takes the current scenes name and loads.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
