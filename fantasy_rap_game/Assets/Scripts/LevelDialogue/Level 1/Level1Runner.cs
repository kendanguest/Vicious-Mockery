/*
 * Name: Jackson Miller
 * Date: 12/4/23
 * Desc: Runs all the Dialogue for level 1 in a sequence.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Runner : MonoBehaviour
{
    public DialogueDisplay dialogue;
    public GameObject UI;
    public DialogueObject prefightDialogue;
    public DialogueObject tutorial_1;
    public DialogueObject rap1;
    public DialogueObject tutorial_2;
    public DialogueObject rap2;
    public DialogueObject postRap;
    public wordRandomizer random;
    public ComplimentRandomizer Crandom;
    public RapShadowController RSC;
    public SpawnDodgeMinigame SDM;
    public bool progress;
    public int line;
    // Start is called before the first frame update
    void Start()
    {
        // This starts the Coroutine.
        SDM = FindObjectOfType<SpawnDodgeMinigame>();
        UI.SetActive(false);
        dialogue.currentDialogue = prefightDialogue;
        dialogue.DisplayDialogue(prefightDialogue);
        StartCoroutine(startlevel());
    }
    IEnumerator startlevel()
    {
        // This IEnumerator controls when the dialogue spawns.
        // 312 beats 180 BPM.
        yield return new WaitForSeconds(1);
        UI.SetActive(true);
        yield return new WaitUntil(() => (progress == true));
        UI.SetActive(true);
        progress = false;
        dialogue.currentDialogue = tutorial_1;
        dialogue.DisplayDialogue(tutorial_1);
        yield return new WaitUntil(() => (progress == true));
        UI.SetActive(true);
        progress = false;
        dialogue.currentDialogue = rap1;
        dialogue.DisplayDialogue(rap1);
        yield return new WaitUntil(() => line == 0);
        newPlayerTurn(line, "ADJ");
        yield return new WaitUntil(() => line == 1);
        newPlayerTurn(line, "ADJ");
        yield return new WaitUntil(() => line == 2);
        newPlayerTurn(line, "Noun");
        yield return new WaitUntil(() => line == 3);
        newPlayerTurn(line, "ADJ");
        yield return new WaitUntil(() => (progress == true));
        UI.SetActive(true);
        progress = false;
        dialogue.currentDialogue = tutorial_2;
        dialogue.DisplayDialogue(tutorial_2);
        yield return new WaitUntil(() => (progress == true));
        UI.SetActive(true);
        progress = false;
        line = 0;
        dialogue.currentDialogue = rap2;
        dialogue.DisplayDialogue(rap2);
        yield return new WaitUntil(() => line == 0);
        SDM.startDodgeGame(6, 120);
        yield return new WaitUntil(() => line == 1);
        SDM.startDodgeGame(6, 120);
        yield return new WaitUntil(() => line == 2);
        SDM.startDodgeGame(9, 120);
        yield return new WaitUntil(() => line == 3);
        SDM.startDodgeGame(11, 120);

    }

    private void newPlayerTurn(int line, string type)
    {
        // Updates the shadow line and creates the words needed.
        RSC.shadowRap(line);
        random.createWord(7, type);
        Crandom.createCompliment(2, type);
    }
}