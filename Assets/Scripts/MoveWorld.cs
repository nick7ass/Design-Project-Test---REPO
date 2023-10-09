using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWorld : MonoBehaviour
{

    public float speed;

    private float outOfBound = 0;

    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = gameManager.GetComponent<GameManager>();
        speed = 15.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //While isGameActive var in Game Manager is true this moves both
        //backgrounds (left and right) and Ground objects since they
        //all have this script attached
        if (gameManager.isGameActive)
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }

        //Destroys obstacles that is out of screen
        if (transform.position.z < outOfBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
