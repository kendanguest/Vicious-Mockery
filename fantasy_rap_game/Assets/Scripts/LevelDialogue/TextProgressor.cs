/*
 * Name: Jackson Miller
 * Date: 12/4/23
 * Desc: Helps progress the text forward.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextProgressor : MonoBehaviour
{
    public Level1Runner level1;
    public void progressText()
    {
        level1.progress = true;
    }
}
