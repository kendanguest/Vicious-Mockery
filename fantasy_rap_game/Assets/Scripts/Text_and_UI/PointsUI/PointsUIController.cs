/*
 * Name: Jackson Miller
 * Date: 1/5/24
 * Desc: Updates the text boxes at the top of the screen to show point gain and loss, along with current game state.
 */
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class PointsUIController : MonoBehaviour
{
    public TMP_Text playerPointsZone;
    public TMP_Text enemyPointsZone;
    public TMP_Text gameState1;
    public TMP_Text gameState2;
    private pointsArrow points;
    private string currentCombo;
    // Start is called before the first frame update
    void Start()
    {
        points = FindObjectOfType<pointsArrow>();
        gameState1.text = "Dead";
        gameState2.text = "even!";
    }
    public void displayPointChange(float points, List<int> mod, string word)
    {
        enemyPointsZone.text = "";
        playerPointsZone.text = "";
        if(points > 0)
        {
            currentCombo = currentCombo + "+";
        }
        currentCombo = currentCombo + points.ToString() + "!";
        if (word == "Uhhhh")
        {
            currentCombo = currentCombo + "\nslip up!";
        }
        for (int i = 0; i < mod.Count; i++)
        {
            if(mod[i] > 0)
            {
                currentCombo = currentCombo + "\nRhyme Bonus!";
            }
            if (mod[i] < 0)
            {
                currentCombo = currentCombo + "\nRhythm Bonus!";
            }
            if (mod[i] > 1 || mod[i] < -1)
            {
                currentCombo = currentCombo + "\nx2!";
            }

        }
        if(points < 0)
        {
            enemyPointsZone.text = currentCombo;
        }
        else
        {
            playerPointsZone.text = currentCombo;
        }
        currentCombo = "";
        if(points > 10)
        {
            if(points > 50)
            {
                gameState1.text = "Total";
                gameState2.text = "slaughter!";
            }
            else
            {
                gameState1.text = "You're";
                gameState2.text = "winning!";
            }
        }
        else if (points < -10)
        {
            if (points < -50)
            {
                gameState1.text = "Complete";
                gameState2.text = "loss!";
            }
            else
            {
                gameState1.text = "You're";
                gameState2.text = "losing!";
            }
        }
        else
        {
            gameState1.text = "Dead";
            gameState2.text = "even!";
        }
    }


}
