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
    [SerializeField] private TMP_Text dialogueNameText;
    public TMP_Text spaceTooltip;
    public DialogueObject currentDialogue;
    public TextProgressor textP;
    public RapShadowController RSC;
    public int level;
    private List<string> rap = new List<string>();
    private string input = "Uhhhh";

    private void Start()
    {
        // Activates or deactivates the "space to proeed" tooltip.
        if(currentDialogue.pressSpaceToContinue)
        {
            spaceTooltip.text = "Press space to proceed";
        }
        else
        {
            spaceTooltip.text = "";
        }
    }
    private IEnumerator MoveThroughDialogue(DialogueObject dia)
    {
        for(int i = 0; i < dia.dialogueLines.Length; i++)
        {
            nameDetermination(currentDialogue.name1, currentDialogue.name2, currentDialogue.talking[i]);
            dialogueText.text = dia.dialogueLines[i].dialogue;
            // The dialogue pauses while it waits for you to press E.
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
            // Buffer to not skip lines.
            yield return null;
        }
        // Deactivates the dialogue box on completion of the dialogue.
        textP.progressText(level);
        dialogueText.text = "";
        dialogueBox.SetActive(false);
    }
    private IEnumerator MoveThroughRap(List<string> rap, int BPM)
    {
        // Determines the interval between beats.
        float beat = 60.0f / BPM;
        int j = 0;
        input = "Uhhhh";
        for (int i = 0; i < rap.Count; i++)
        {
            if(i == 0)
            {
                nameDetermination(currentDialogue.name1, currentDialogue.name2, currentDialogue.talking[i]);
            }
            // Waits the interval determined previously.
            yield return new WaitForSeconds(beat);
            // Checks if the current word in the list is a player input and removes it as time has run out.
            if (rap[i].Substring(0, rap[i].Length - 1) == "[Input]")
            {
                rap[i] = input + rap[i].Substring(rap[i].Length - 1);
            }
            if (rap[i] == "_")
            {
                // If it is, it will wait if you need to push space, either way, it will instantly clear and start the next line.
                if (currentDialogue.pressSpaceToContinue)
                {
                    yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
                }
                else
                {
                    yield return new WaitForSeconds(beat);
                    yield return new WaitForSeconds(beat);
                    yield return new WaitForSeconds(beat);
                }
                textP.linecount();
                RSC.eraseLine();
                i++;
                j++;
                dialogueText.text = rap[i];
                input = "Uhhhh";
                nameDetermination(currentDialogue.name1, currentDialogue.name2, currentDialogue.talking[j]);
            }
            else
            {
                // Appends the current word to the line of dialogue.
                dialogueText.text = dialogueText.text + rap[i];
            }
        }
        RSC.eraseLine();
        yield return new WaitForSeconds(beat);
        yield return new WaitForSeconds(beat);
        yield return new WaitForSeconds(beat);
        textP.progressText(level);
        dialogueText.text = "";
        dialogueBox.SetActive(false);
    }
    public void DisplayDialogue(DialogueObject dialogue)
    {
        // Activates or deactivates the "space to proeed" tooltip.
        if (currentDialogue.pressSpaceToContinue)
        {
            spaceTooltip.text = "Press space to proceed";
        }
        else
        {
            spaceTooltip.text = "";
        }
        // Checks to see if the line has a BPM, indicating it's a rap line.
        if (dialogue.BPM < 1)
        {
            StartCoroutine(MoveThroughDialogue(dialogue));
        }
        else
        {
            // Initializes and creates a list of all the words in the line of dialogue.
            RSC.recieveRapDialogue(dialogue);
            for (int i = 0; i < dialogue.dialogueLines.Length; i++)
            {
                string word = "";
                for (int j = 0; j < dialogue.dialogueLines[i].dialogue.Length; j++)
                {
                    if (dialogue.dialogueLines[i].dialogue[j] != ' ' && dialogue.dialogueLines[i].dialogue[j] != '-')
                    {
                        word = word + dialogue.dialogueLines[i].dialogue[j];              
                    }
                    else
                    {
                        if(dialogue.dialogueLines[i].dialogue[j] == '-')
                        {
                            word = word + "-";
                        }
                        else
                        {
                            word = word + " ";
                        }
                        rap.Add(word);
                        word = "";
                    }
                }
                rap.Add(word);
                if(i < dialogue.dialogueLines.Length - 1)
                {
                    rap.Add("_");
                }
            }
            StartCoroutine(MoveThroughRap(rap, dialogue.BPM));
        }
    }
    public void nameDetermination(string name1, string name2, int talking)
    {
        // This function simply determines who is speaking.
        if(talking == 1)
        {
            dialogueNameText.text = name1;
        }
        else if(talking == 2)
        {
            dialogueNameText.text = name2;
        }
        else
        {
            dialogueNameText.text = "";
        }
    }
    public void inputUpdate(string word)
    {
        input = word;
        RSC.updateTextBoxWithSelectedWord(word);
    }
}

