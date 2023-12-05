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
    public DialogueObject rap;
    public DialogueObject postRap;
    public wordRandomizer random;
    public RapShadowController RSC;
    public bool progress;
    public int line;
    // Start is called before the first frame update
    void Start()
    {
        // This starts the Coroutine.
        UI.SetActive(false);
        dialogue.DisplayDialogue(prefightDialogue);
        StartCoroutine(startlevel());
    }
    IEnumerator startlevel()
    {
        // This IEnumerator controls when the dialogue spawns.
        yield return new WaitForSeconds(2);
        UI.SetActive(true);
        yield return new WaitUntil(() => (progress == true));
        UI.SetActive(true);
        progress = false;
        dialogue.currentDialogue = rap;
        dialogue.DisplayDialogue(rap);
        // This is a very stupid solution, but for loops are even more work.
        yield return new WaitUntil(() => (line == 4));
        newPlayerTurn(line);
        yield return new WaitUntil(() => (line == 5));
        newPlayerTurn(line);
        yield return new WaitUntil(() => (line == 6));
        newPlayerTurn(line);
        yield return new WaitUntil(() => (line == 7));
        newPlayerTurn(line);
        yield return new WaitUntil(() => (progress == true));
        UI.SetActive(true);
        progress = false;
        dialogue.currentDialogue = postRap;
        dialogue.DisplayDialogue(postRap);
    }

    private void newPlayerTurn(int line)
    {
        // Updates the shadow line and creates the words needed.
        RSC.shadowRap(line);
        random.createWord(7, "ADJ");
    }
}