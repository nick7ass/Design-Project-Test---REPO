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
        button = GetComponent<Button>();

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        //Starts game by calling the StartGame method in Game Manager
        button.onClick.AddListener(gameManager.StartGame);
          
    }

}
