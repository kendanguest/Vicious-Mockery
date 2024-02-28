/*
 * Name: Jackson Miller
 * Date: 12/1/23
 * Desc: Controls the transition graphic between levels.
 */
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TransitionBehavior : MonoBehaviour
{
    public GameObject square;
    public string beforetext;
    public string aftertext;
    public TMP_Text text;
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
        text.text = beforetext;
        yield return new WaitForSeconds(5f);
        text.text = "";
        pos.velocity = (new Vector3(0, -10, 0));
        yield return new WaitForSeconds(2f);
        pos.velocity = (new Vector3(0, 0, 0));
    }

    public IEnumerator fadeIn()
    {
        pos.velocity = (new Vector3(0, 10, 0));
        yield return new WaitForSeconds(2f);
        pos.velocity = (new Vector3(0, 0, 0));
        text.text = aftertext;
    }
}
