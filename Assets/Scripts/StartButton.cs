using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    private Button button;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        //The AddListener makes it so it listens to possible input ig? typ gör så att den funkar alltså
        //man typ listening for the function (därav inga paranteser)

        button = GetComponent<Button>();

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();


        button.onClick.AddListener(makeGameStart);
        
    }

    private void makeGameStart()
    {
        gameManager.StartGame();
        Debug.Log("Start Button was clicked");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
