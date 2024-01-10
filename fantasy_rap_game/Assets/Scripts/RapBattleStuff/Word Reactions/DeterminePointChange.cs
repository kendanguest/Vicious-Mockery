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
    public PointsUIController controller;
    private float mod = 1f;
    private List<string> previous = new List<string>();
    private List<int> mods = new List<int>();
    public void implementPoints(float value, string word)
    {
        // Checks if the previous ending matches with the current ending. 
        if(previous.Count > 0)
        {
            if(previous[previous.Count-1].Substring(previous[previous.Count-1].Length - 2) == word.Substring(word.Length - 2))
            {
                // If it does, it doubles the modifier.
                mod += 1f;
                mods.Add(1);
            }
            else if (previous[previous.Count - 1].Substring(previous[previous.Count - 1].Length - 1) == word.Substring(word.Length - 1))
            {
                // If it does with 1 letter, it adds 0.5 to the modifier.
                mod += 0.5f;
                mods.Add(-1);
            }
            if (previous.Count > 1)
            {
                if (previous[previous.Count - 2].Substring(previous[previous.Count - 2].Length - 2) == word.Substring(word.Length - 2))
                {
                    // If it matches with the one before the last one, it is multiplied by 1.5.
                    mod *= 1.5f;
                    mods.Add(2);
                }
                else if (previous[previous.Count - 2].Substring(previous[previous.Count - 2].Length - 1) == word.Substring(word.Length - 1))
                {
                    // If it matches with the one before the last one, with one letter it is multiplied by 1.25.
                    mod *= 1.25f;
                    mods.Add(-2);
                }
            }
            // checks to see if the words are the exact same.
            if (previous[previous.Count - 1] == word)
            {
                mod *= -1f;
            }
        }
        // adds and resets the point values.
        if(word == "Uhhhh")
        {
            value = -3f;
            previous.Add(word);
        }
        else
        {
            previous.Add(word);
        }
        arrow.points += (value * mod);
        controller.displayPointChange(value * mod, mods, word);
        mods.Clear();
        mod = 1f;
    }
}
