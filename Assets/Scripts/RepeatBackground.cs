using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    private float BoxColliderwidth;
    void Start()
    {
        BoxColliderwidth = GetComponent<BoxCollider>().size.x / 2;
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < startPos.x - BoxColliderwidth)
        {
            transform.position = startPos;   
            
        }
    }
}
