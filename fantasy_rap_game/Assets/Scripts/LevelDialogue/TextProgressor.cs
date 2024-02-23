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
    public Level2Runner level2;
    public Level3Runner level3;
    public void progressText(int level)
    {
        // Progresses the dialogue further.
        if(level == 1)
        {
            level1.progress = true;
        }
        else if (level == 2)
        {
            level2.progress = true;
        }
        else if (level == 3)
        {
            level3.progress = true;
        }
    }
    public void linecount(int level)
    {
        // Increments the line count to help progress the dialogue.
        if (level == 1)
        {
            level1.line += 1;
        }
        else if (level == 2)
        {
            level2.line += 1;
        }
        else if (level == 3)
        {
            level3.line += 1;
        }
    }
}
