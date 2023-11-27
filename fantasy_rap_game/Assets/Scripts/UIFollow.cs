/*
 * Name: Jackson Miller
 * Date: 11/27/23
 * Desc: Attach to UI elements that are to follow the player.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFollow : MonoBehaviour
{
    public GameObject player;
    private SpriteRenderer mySR;
    private int toggle = 0;
    private Camera myC = FindObjectOfType<Camera>();
    // Start is called before the first frame update
    void Start()
    {
        mySR = GetComponent<SpriteRenderer>();
        mySR.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = player.transform.position;
    }
    void UIEnableToggle()
    {
        if (toggle == 0)
        {
            toggle = 1;
            mySR.enabled = true;
        }
        else
        {
            toggle = 0;
            mySR.enabled = false;
        }
    }
}
