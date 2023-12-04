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
    public bool progress;
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
        print("fire");
        UI.SetActive(true);
        progress = false;
        dialogue.DisplayDialogue(rap);
    }
}