using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWorld : MonoBehaviour
{
    private float speed = 15.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //lägg till if statement för att bedödma om gamet är startat typ en bool
        //Moves both backgrounds (left and right) and Ground objects since they all have this script attached
        transform.Translate(Vector3.back * Time.deltaTime * speed);
    }
}
