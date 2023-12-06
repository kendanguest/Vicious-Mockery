using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlayer : MonoBehaviour
{
    public float speed;
    public GameObject center;
    public float keyboardNerfMultiplier;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.RotateAround(center.transform.position, Vector3.forward, speed* (Input.mouseScrollDelta.y+(Input.GetAxis("Horizontal")*keyboardNerfMultiplier*-1)));
    }
}
