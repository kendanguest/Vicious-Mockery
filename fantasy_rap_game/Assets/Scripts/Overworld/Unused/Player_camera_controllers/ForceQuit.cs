/*
 * Name: Jackson Miller
 * Date: 10/3/23
 * Desc: Forces the program to quit when esc. is pressed.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceQuit : MonoBehaviour
{
   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
