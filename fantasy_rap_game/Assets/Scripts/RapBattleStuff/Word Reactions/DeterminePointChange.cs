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
    public void implementPoints(float value)
    {
        arrow.points += value;
    }
}
