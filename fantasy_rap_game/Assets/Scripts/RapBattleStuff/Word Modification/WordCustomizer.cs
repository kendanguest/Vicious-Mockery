/*
 * Name: Jackson Miller
 * Date: 12/1/23
 * Desc: Attached to the Prefab to store the word values.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WordCustomizer : MonoBehaviour
{
    public TMP_Text text;
    public string wordO;
    public float valueO;
    public string partOfSpeech;
    public void selfUpdate(string word, float value, string POS)
    {
        text.text = word;
        wordO = word;
        valueO = value;
        partOfSpeech = POS;
    }
}
