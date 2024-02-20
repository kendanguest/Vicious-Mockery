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
        // This script is really braindead, but it moves the black box out of the way essentially simulating a smooth transition.
        pos = square.GetComponent<Rigidbody2D>();
        StartCoroutine(fadeOut());
    }

    IEnumerator fadeOut()
    {
        pos.velocity = (new Vector3(0, -10, 0));
        yield return new WaitForSeconds(2f);
        pos.velocity = (new Vector3(0, 0, 0));
    }

    public IEnumerator fadeIn()
    {
        pos.velocity = (new Vector3(0, 10, 0));
        yield return new WaitForSeconds(2f);
        pos.velocity = (new Vector3(0, 0, 0));
    }
}
