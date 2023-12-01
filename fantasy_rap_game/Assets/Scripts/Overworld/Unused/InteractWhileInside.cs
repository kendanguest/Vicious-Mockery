/*
 * Name: Jackson Miller
 * Date: 11/27/23
 * Desc: Attach to invisible triggers to allow the player to initiate conversation while inside.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWhileInside : MonoBehaviour
{
    public GameObject player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
    //Calls the textbox code if the player is standing within the object's range and presses E.
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            
        }
    }
}
