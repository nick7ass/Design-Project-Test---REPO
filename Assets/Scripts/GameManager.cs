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

    //VET INTE OM JAG BEHÖVER DENNA ENS? ÄVEN I START
    //public PlayerController playerControllerScript;

    //Var for storing the score
    private int score;

    //Var for spawnRate
    private float spawnRate;

    public bool isGameActive = false;

    // Start is called before the first frame update
    void Start()
    {
        //VET INTE OM JAG BEHÖVER DENNA ENS? ÄVEN OVAN
        //playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        //SPAWNRATE fixa så den ökar med tid? så länge gör jag såhär:
        //!!!!!!!!!!!!!
        spawnRate = 1.0f;

        //Starts function that starts the game
        isGameActive = true;

        Debug.Log("I clicked on start");

        //Makes it so the start button and title text disappers when game starts
        titleScreen.SetActive(false);

        StartCoroutine(SpawnTarget());

        score = 0;

        UpdateScore(10);
    }

    IEnumerator SpawnTarget()
    {
        //The isGameActive variable we define as true in start, but false in Game over function, which is
        //why this works to make it stop spawning things when gameover
        while (isGameActive)
        {
            
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, obstacles.Count);
            Instantiate(obstacles[index]);
        }
    }

    //Method to update and show the score. Public to be able to reach it from "Target" script
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;

        //Displaying the score 
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
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
