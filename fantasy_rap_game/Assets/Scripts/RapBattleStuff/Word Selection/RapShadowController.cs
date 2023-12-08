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
    private int inputPos;
    private int previousWordLength;
    public void recieveRapDialogue(DialogueObject rapinput)
    {
        rap.Clear();
        // Backlogs the dialogue to be accessed later.
        for(int i = 0; i < rapinput.dialogueLines.Length; i++)
        {
            rap.Add(rapinput.dialogueLines[i]);
        }
    }
    public void shadowRap(int line)
    {
        // Acesses the dialogue backloged previously.
        inputPos = rap[line].dialogue.IndexOf('[');
        textBox.text = rap[line].dialogue.Substring(0, inputPos) + rap[line].dialogue.Substring(rap[line].dialogue.IndexOf(']') + 1) + "";
    }
    public void updateTextBoxWithSelectedWord(string word)
    {
        // Updates the text to include what word is selected.
        textBox.text = textBox.text.Substring(0, inputPos) + word + textBox.text.Substring(inputPos + previousWordLength);
        previousWordLength = word.Length;
    }
    public void eraseLine()
    {
        // Clears the textbox.
        textBox.text = "";
        previousWordLength = 0;
    }
}
