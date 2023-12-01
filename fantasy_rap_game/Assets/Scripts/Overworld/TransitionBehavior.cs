/*
 * Name: Jackson Miller
 * Date: 12/1/23
 * Desc: Controls the transition graphic between levels.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionBehavior : MonoBehaviour
{
    public GameObject square;
    private Rigidbody2D pos;
    // Start is called before the first frame update
    void Start()
    {
        pos = square.GetComponent<Rigidbody2D>();
        fadeOut();
    }

    public void fadeOut()
    {
        pos.velocity = (new Vector3(0, -10, 0));
    }
}
