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

        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        button.onClick.AddListener(gameManager.StartGame);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
