using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWorld : MonoBehaviour
{
    private float speed = 15.0f;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        //makeWorldMove();
    }

    void makeWorldMove()
    {
        //While isGameActive var in Game Manager is true this moves both
        //backgrounds (left and right) and Ground objects since they
        //all have this script attached

        while (gameManager.isGameActive)
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
    }
}
