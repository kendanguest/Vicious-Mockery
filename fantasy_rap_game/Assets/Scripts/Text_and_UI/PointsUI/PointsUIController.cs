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
    private pointsArrow pointsA;
    private bool rhyme = false;
    private bool rhyme2 = false;
    private string currentCombo;
    // Start is called before the first frame update
    void Start()
    {
        pointsA = FindObjectOfType<pointsArrow>();
        gameState1.text = "It's";
        gameState2.text = "even!";
    }
    // Called when the pointer updates, and adjusts UI accordingly.
    public void displayPointChange(float points, List<int> mod, string word)
    {
        enemyPointsZone.text = "";
        playerPointsZone.text = "";
        // Determines if the point change is positive or negative and adds it to the combo text.
        if(points > 0)
        {
            currentCombo = currentCombo + "+";
        }
        currentCombo = currentCombo + points.ToString() + "!";
        // Determines if the word is the filled-in response and adds a new line to the combo text.
        if (word == "Uhhhh")
        {
            currentCombo = currentCombo + "\nslip up!";
        }
        // Determines if the word is the pushed response from the dodge minigame.
        if (word == "" && points != 0)
        {
            currentCombo = currentCombo + "\noof!";
        }
        // Adds new data to the combo text for all of the modifiers applied to the word.
        for (int i = 0; i < mod.Count; i++)
        {
            if(mod[i] > 0 && rhyme == false)
            {
                currentCombo = currentCombo + "\nRhyme Bonus!";
                rhyme = true;
            }
            if (mod[i] < 0 && rhyme2 == false)
            {
                currentCombo = currentCombo + "\nRhythm Bonus!";
                rhyme2 = true;
            }

        }
        // Removes the text if the point change is zero.
        if (points == 0)
        {
            currentCombo = "";
        }
        // Checks one more time if it's a negative or positive bonus and applies it to the correct area.
        if(points < 0)
        {
            enemyPointsZone.text = currentCombo;
        }
        else
        {
            playerPointsZone.text = currentCombo;
        }
        currentCombo = "";
        // This block of if statements will update the flavor text in the middle depending on how good or bad the player is doing.
        if(pointsA.points > 10)
        {
            if(pointsA.points > 50)
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
        else if (pointsA.points < -10)
        {
            if (pointsA.points < -50)
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
            gameState1.text = "It's";
            gameState2.text = "even!";
        }
        rhyme = false;
        rhyme2 = false;
    }


}
