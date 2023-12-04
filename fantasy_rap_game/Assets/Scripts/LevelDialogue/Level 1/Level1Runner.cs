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
    public DialogueObject prefightDialogue;
    public DialogueObject rap;
    // Start is called before the first frame update
    void Start()
    {
        dialogue.DisplayDialogue(prefightDialogue);
    }
}