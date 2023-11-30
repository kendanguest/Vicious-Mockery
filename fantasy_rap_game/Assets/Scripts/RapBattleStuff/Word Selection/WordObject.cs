/*
 * Name: Jackson Miller
 * Date: 11/30/23
 * Desc: Attached to instantiated words to give them thier predetermined values.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Allows this ScriptableObject to be created from the Unity Editor itself.
[CreateAssetMenu(menuName = "Dialogue/WordObject")]
public class WordObject : ScriptableObject
{
    string wordO;
    float valueO;
    string partOfSpeech;
    public void selfUpdate(string word, float value, string POS)
    {
        wordO = word;
        valueO = value;
        partOfSpeech = POS;
    }
}
