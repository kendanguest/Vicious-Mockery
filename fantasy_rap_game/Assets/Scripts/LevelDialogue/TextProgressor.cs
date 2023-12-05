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
    public void progressText(int level)
    {
        // Progresses the dialogue further.
        if(level == 1)
        level1.progress = true;
    }
    public void linecount()
    {
        // Increments the line count to help progress the dialogue.
        level1.line += 1;
    }
}
