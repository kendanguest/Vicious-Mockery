/*
 * Name: Jackson Miller
 * Date: 11/28/23
 * Desc: A single line of Dialogue, used by the DialogueObject
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This makes the dialogueLines appear in-engine when they need to be modified later.
[System.Serializable]
public class DialogueLine
{
    [TextArea] public string dialogue;
}
