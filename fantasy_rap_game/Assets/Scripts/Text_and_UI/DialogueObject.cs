/*
 * Name: Jackson Miller
 * Date: 11/28/23
 * Desc: An array of DialogueLines which is used to make a conversation.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Allows this ScriptableObject to be created from the Unity Editor itself.
[CreateAssetMenu(menuName = "Dialogue/DialogueObject")]
public class DialogueObject : ScriptableObject
{
    public DialogueLine[] dialogueLines;
}
