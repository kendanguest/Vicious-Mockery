/*
 * Name: Jackson Miller
 * Date: 11/28/23
 * Desc: Connects the Dialouge to the UI.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueDisplay : MonoBehaviour
{
    
    // SerializeField makes the private variables actually storable.
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text dialogueText;
    public DialogueObject currentDialogue;
    private void Start()
    {
        DisplayDialogue(currentDialogue);
    }
    private IEnumerator MoveThroughDialogue(DialogueObject dia)
    {
        for(int i = 0; i < dia.dialogueLines.Length; i++)
        {
            dialogueText.text = dia.dialogueLines[i].dialogue;
            // The dialogue pauses while it waits for you to press E.
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
            // Buffer to not skip lines.
            yield return null;
        }
        // Deactivates the dialogue box on completion of the dialogue.
        dialogueBox.SetActive(false);
    }
    public void DisplayDialogue(DialogueObject dialogue)
    {
        StartCoroutine(MoveThroughDialogue(dialogue));
    }
}

