/*
 * Name: Jackson Miller
 * Date: 2/26/23
 * Desc: This script is just used to reset the time that is frozen when accessing the pause menu.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetTimescale : MonoBehaviour
{
    // This is a function just so onclick can call it.
    public void resetTime()
    {
        Time.timeScale = 1.0f;
    }
}
