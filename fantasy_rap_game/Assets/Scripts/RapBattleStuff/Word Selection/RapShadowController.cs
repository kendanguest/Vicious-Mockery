/*
 * Name: Jackson Miller
 * Date: 12/5/23
 * Desc: Shadow-writes the Rap text before it's spoken. Allowing the user to see the words before they appear
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RapShadowController : MonoBehaviour
{
    public TMP_Text textBox;
    private List<DialogueLine> rap = new List<DialogueLine>();
    public void recieveRapDialogue(DialogueObject rapinput)
    {
        // Backlogs the dialogue to be accessed later.
        for(int i = 0; i < rapinput.dialogueLines.Length; i++)
        {
            rap.Add(rapinput.dialogueLines[i]);
        }
    }
    public void shadowRap(int line)
    {
        // Acesses the dialogue backloged previously.
        textBox.text = rap[line].dialogue + "";
    }
    public void eraseLine()
    {
        // Clears the textbox.
        textBox.text = "";
    }
}
