/*
 * Name: Jackson Miller
 * Date: 12/6/23
 * Desc: Determines how many points the meter will move by after a word is selected or a mini-game is played and adjusts it accordingly.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeterminePointChange : MonoBehaviour
{
    public pointsArrow arrow;
    private float mod = 1f;
    private List<string> previous = new List<string>();
    public void implementPoints(float value, string word)
    {
        // Checks if the previous ending matches with the current ending. 
        if(previous.Count > 0)
        {
            if(previous[previous.Count].Substring(previous[previous.Count].Length - 2) == word.Substring(word.Length - 2))
            {
                // If it does, it doubles the modifier.
                mod += 1f;
            }
            if(previous.Count > 1)
            {
                if (previous[previous.Count - 1].Substring(previous[previous.Count - 1].Length - 2) == word.Substring(word.Length - 2))
                {
                    // If it matches with the one before the last one, it is multiplied by 1.5.
                    mod *= 1.5f;
                }
            }
        }
        // adds and resets the point values.
        previous.Add(word);
        arrow.points += (value * mod);
        mod = 1f;
    }
}
