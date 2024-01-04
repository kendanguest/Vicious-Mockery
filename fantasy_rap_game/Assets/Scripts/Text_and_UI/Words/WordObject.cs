/*
 * Name: Jackson Miller
 * Date: 1/4/24
 * Desc: A single word object, complete with it's point value, part of speech, etc.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Allows this ScriptableObject to be created from the Unity Editor itself.
[CreateAssetMenu(menuName = "Dialogue/WordObject")]
public class WordObject : ScriptableObject
{
    public string word;
    public float points;
    public string partOfSpeech;
    public string suffix = "";
}
