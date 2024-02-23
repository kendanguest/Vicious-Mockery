/*
 * Name: Jackson Miller
 * Date: 2/23/24
 * Desc: Operates the UI that displays previous words.
 */
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RhymeUI : MonoBehaviour
{
    public TMP_Text word1;
    public TMP_Text word2;
    // Start is called before the first frame update
    void Start()
    {
        word1.text = "";
        word2.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void newWord(string word)
    {
        word2.text = word1.text;
        word1.text = word;
    }
}
