/*
 * Name: Jackson Miller
 * Date: 11/28/23
 * Desc: Connects the Dialouge to the UI.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine.UI;

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
    public RawImage pframe;
    public RawImage eframe;
    private List<string> rap = new List<string>();
    private string input = "Uhhhh";
    private DeterminePointChange DPC;
    private WordRemover wordRemove;
    private string lookoutWord;
    private PlayBlip blip;
    private bool dialoActive;
    private string currentline;
    private bool clockFlag;
    private float beat = 60.0f;

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
        DPC = FindObjectOfType<DeterminePointChange>();
        wordRemove = FindObjectOfType<WordRemover>();
        blip = FindObjectOfType<PlayBlip>();
    }
    private void Update()
    {
        // Skips the current dialogue showcase and just shows the whole line.
        if(Input.GetKeyDown(KeyCode.Space) && dialoActive)
        {
            dialoActive = false;
            dialogueText.text = currentline;
        }
    }

    private IEnumerator MoveThroughDialogue(DialogueObject dia)
    {
        for(int i = 0; i < dia.dialogueLines.Length; i++)
        {
            dialoActive = true;
            currentline = dia.dialogueLines[i].dialogue;
            int nameI = nameDetermination(currentDialogue.name1, currentDialogue.name2, currentDialogue.talking[i]);
            // This loop allows the dialogue to be shown one letter at a time.
            for(int j = 0; j < dia.dialogueLines[i].dialogue.Length; j++)
            {
                if (dialoActive)
                {
                    dialogueText.text += dia.dialogueLines[i].dialogue[j] + "";
                    yield return new WaitForSeconds(0.02f);
                    // Plays a random blip SFX for the character (removed, too jarring).
                    // blip.playBlip(nameI);
                }
            }
            // Buffers the skip input so it doesn't force skip dialogue.
            yield return new WaitForSeconds(0.1f);
            // The dialogue pauses while it waits for you to press Space.
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
            dialogueText.text = "";
            // Buffer to not skip lines.
            yield return null;
        }
        // Deactivates the dialogue box on completion of the dialogue.
        textP.progressText(level);
        dialogueText.text = "";
        dialoActive = false;
        dialogueBox.SetActive(false);
    }
    private IEnumerator MoveThroughRap(List<string> rap, int BPM)
    {
        // Determines the interval between beats.
        beat = 60.0f / BPM;
        int j = 0;
        int nameI = 0;
        input = "Uhhhh";
        clockFlag = true;
        for (int i = 0; i < rap.Count; i++)
        {
            if (i == 0)
            {
                nameI = nameDetermination(currentDialogue.name1, currentDialogue.name2, currentDialogue.talking[i]);
            }
            // Waits the interval determined previously.
            yield return new WaitForSeconds(beat);
            // Checks if the current word in the list is a player input and removes it as time has run out.
            if (rap[i].Substring(0, rap[i].Length - 1) == "[Input]")
            {
                RSC.updateTextBoxWithSelectedWord(input);
                rap[i] = input + rap[i].Substring(rap[i].Length - 1);
                if(FindObjectOfType<wordGetter>().lastClickedWord != null)
                    DPC.implementPoints(FindObjectOfType<wordGetter>().lastClickedWord.GetComponent<WordCustomizer>().valueO, input);
                else
                    DPC.implementPoints(0f, input);
                Destroy(GameObject.FindGameObjectWithTag("Line"));
                wordRemove.refreshAllKnownWords();
                wordRemove.destroyAllKnownWords();
            }
            if (clockFlag && i + 4 <= rap.Count)
            {
                if(rap[i + 4].Substring(0, rap[i + 4].Length - 1) == "[Input]" || rap[i + 4].Substring(0, rap[i + 4].Length - 1) == lookoutWord)
                {
                    clockFlag = false;
                    blip.playClock();
                }

            }
            // Checks if the current word is the trigger word for the enemy minigame.
            else if (rap[i].Substring(0, rap[i].Length - 1) == lookoutWord)
            {
                FindObjectOfType<DamageMitigationCheck>().terminateMinigame();
            }
            // Checks to see if the current word is the internal character for newline.
            if (rap[i] == "_")
            {
                // If it is, it will wait if you need to push space, either way, it will instantly clear and start the next line.
                if (currentDialogue.pressSpaceToContinue)
                {
                    yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
                }
                else
                {
                    yield return new WaitForSeconds(beat * 3);
                }
                textP.linecount(level);
                RSC.eraseLine();
                i++;
                j++;
                dialogueText.text = rap[i];
                input = "Uhhhh";
                clockFlag = true;
                nameDetermination(currentDialogue.name1, currentDialogue.name2, currentDialogue.talking[j]);
            }
            else
            {
                // Appends the current word to the line of dialogue.
                dialogueText.text = dialogueText.text + rap[i];
                
            }
        }
        RSC.eraseLine();
        yield return new WaitForSeconds(beat * 3);
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
            rap.Clear();
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
                if (i < dialogue.dialogueLines.Length - 1)
                {
                    rap.Add("_");
                }
            }
            StartCoroutine(MoveThroughRap(rap, dialogue.BPM));
        }
    }
    public int nameDetermination(string name1, string name2, int talking)
    {
        // This function simply determines who is speaking.
        if(talking == 1)
        {
            dialogueNameText.text = name1;
            eframe.color = Color.gray;
            pframe.color = Color.white;
            return 1;
        }
        else if(talking == 2)
        {
            dialogueNameText.text = name2;
            pframe.color = Color.gray;
            eframe.color = Color.white;
            return 2;
        }
        else
        {
            dialogueNameText.text = "";
            eframe.color = Color.gray;
            pframe.color = Color.gray;
            return 0;
        }
    }
    public void inputUpdate(string word)
    {
        // Updates the word that will be submitted with the current word selected.
        input = word;
        RSC.updateTextBoxWithSelectedWord(word);
    }
    public void bpmUpdate(int BPM)
    {
        beat = 60.0f / BPM;
    }
    public void updateLookoutVar(string word)
    {
        // Updates the lookoutWord, for some reason it needs to be done this way.
        lookoutWord = word;
    }

    public void forceTooltipchange(bool t)
    {
        // Forces the space to proceed tooltip to update in real time.
        if (t)
        {
            spaceTooltip.text = "Press space to proceed";
        }
        else
        {
            spaceTooltip.text = "";
        }
    }
}

