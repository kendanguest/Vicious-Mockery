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
    public bool progress;
    public int line;
    // Start is called before the first frame update
    void Start()
    {
        UI.SetActive(false);
        dialogue.DisplayDialogue(prefightDialogue);
        StartCoroutine(startlevel());
    }
    IEnumerator startlevel()
    {
        yield return new WaitForSeconds(2);
        UI.SetActive(true);
        yield return new WaitUntil(() => (progress == true));
        UI.SetActive(true);
        progress = false;
        dialogue.currentDialogue = rap;
        dialogue.DisplayDialogue(rap);
        yield return new WaitUntil(() => (line == 4));
        random.createWord(7, "ADJ");
        yield return new WaitUntil(() => (line == 5));
        random.createWord(7, "Noun");
        yield return new WaitUntil(() => (line == 6));
        random.createWord(7, "ADJ");
        yield return new WaitUntil(() => (line == 7));
        random.createWord(7, "ADJ");
        yield return new WaitUntil(() => (progress == true));
        UI.SetActive(true);
        progress = false;
        dialogue.currentDialogue = postRap;
        dialogue.DisplayDialogue(postRap);
    }
}