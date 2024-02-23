/*
 * Name: Jackson Miller
 * Date: 1/5/24
 * Desc: Updates the text boxes at the top of the screen to show point gain and loss, along with current game state.
 */
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PointsUIController : MonoBehaviour
{
    public TMP_Text playerPointsZone;
    public TMP_Text enemyPointsZone;
    public RawImage playerFrame;
    public Texture pwin;
    public Texture pneutral;
    public Texture plose;
    public RawImage enemyFrame;
    public Texture ewin;
    public Texture eneutral;
    public Texture elose;
    public FollowCamera cam;
    public GenerateNote note;
    public PlayCheers cheer;
    private pointsArrow pointsA;
    private bool rhyme = false;
    private bool rhyme2 = false;
    private string currentCombo;
    private int cclength;
    // Start is called before the first frame update
    void Start()
    {
        pointsA = FindObjectOfType<pointsArrow>();
    }
    // Called when the pointer updates, and adjusts UI accordingly.
    public void displayPointChange(float points, List<int> mod, string word)
    {
        cclength = 0;
        enemyPointsZone.text = "";
        playerPointsZone.text = "";
        // Determines if the word is the filled-in response and adds a new line to the combo text.
        if (word == "Uhhhh")
        {
            currentCombo = currentCombo + "slip up!";
            cclength++;
        }
        if(cclength > 0)
        {
            currentCombo = currentCombo + "\n";
            cclength--;
        }
        
        // Determines if the word is the pushed response from the dodge minigame.
        if (word == "" && points != 0)
        {
            currentCombo = currentCombo + "oof!";
            cclength++;
        }
        if (cclength > 0)
        {
            currentCombo = currentCombo + "\n";
            cclength--;
        }
        // Adds new data to the combo text for all of the modifiers applied to the word.
        for (int i = 0; i < mod.Count; i++)
        {
            if (mod[i] == 0)
            {
                currentCombo = currentCombo + "Duplicate word penalty!";
                rhyme = true;
                rhyme2 = true;
            }
            if (cclength > 0)
            {
                currentCombo = currentCombo + "\n";
                cclength--;
            }
        }
        for (int i = 0; i < mod.Count; i++)
        {
            if (mod[i] > 0 && rhyme == false)
            {
                currentCombo = currentCombo + "Rhyme Bonus!";
                rhyme = true;
                cclength++;
            }
            if (cclength > 0)
            {
                currentCombo = currentCombo + "\n";
                cclength--;
            }
            if (mod[i] < 0 && rhyme2 == false)
            {
                currentCombo = currentCombo + "Motif Bonus!";
                rhyme2 = true;
                cclength++;
            }
            if (cclength > 0)
            {
                currentCombo = currentCombo + "\n";
                cclength--;
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
            cam.StartShake(0.5f, 1f);
            cheer.playBoo();
        }
        else
        {
            playerPointsZone.text = currentCombo;
            note.generateNote(points);
            cheer.playCheer();
        }
        currentCombo = "";
        // This block of if statements will update the portraits depending on how good or bad the player is doing.
        
        if (pointsA.points > 25)
        {
            playerFrame.texture = pwin;
            enemyFrame.texture = elose;
        }

        else if (pointsA.points < -25)
        {
            playerFrame.texture = plose;
            enemyFrame.texture = ewin;
        }
        else
        {
            playerFrame.texture = pneutral;
            enemyFrame.texture = eneutral;
        }
        rhyme = false;
        rhyme2 = false;
    }


}
