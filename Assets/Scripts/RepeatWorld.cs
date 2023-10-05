using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatWorld : MonoBehaviour
{
    private Vector3 startPos;

    private float repeatWidth;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.z / 2;
    }

    // Update is called once per frame
    void Update()
    {
        //if the position on Z is less than half of the boxcollider of object(ground or bg) then move back to startPosition
        if (transform.position.z < startPos.z - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
