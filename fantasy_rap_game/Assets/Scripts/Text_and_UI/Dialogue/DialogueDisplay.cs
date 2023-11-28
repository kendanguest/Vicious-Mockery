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
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
            // Buffer to not skip lines.
            yield return null;
        }
        // Deactivates the dialogue box on completion of the dialogue.
        dialogueBox.SetActive(false);
    }
    private IEnumerator MoveThroughRap(List<string> rap, int BPM)
    {
        float beat = 60.0f / BPM;
        for (int i = 0; i < rap.Count; i++)
        {
            yield return null;
        }
    }
    public void DisplayDialogue(DialogueObject dialogue)
    {
        if(dialogue.BPM < 1)
        {
            StartCoroutine(MoveThroughDialogue(dialogue));
        }
        else
        {
            List<string> rap = new List<string>();
            for (int i = 0; i < dialogue.dialogueLines.Length; i++)
            {
                int start = 0;
                for (int j = 0; j < dialogue.dialogueLines[i].dialogue.Length; j++)
                {
                    print(j);
                    if (dialogue.dialogueLines[i].dialogue[j] == ' ')
                    {
                        rap.Add(dialogue.dialogueLines[i].dialogue.Substring(start, j));
                        start = j;                    
                    }
                }
                print(rap[0]);
                print(rap[1]);
                print(rap[2]);
                print(rap[3]);
            }
            StartCoroutine(MoveThroughRap(rap, dialogue.BPM));
        }
    }
}

