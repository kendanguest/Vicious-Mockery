/*
 * Name: Jackson Miller
 * Date: 11/30/23
 * Desc: Creates words with randomized names and subsequent point values.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wordRandomizer : MonoBehaviour
{
    public string[] words;
    public float[] points;
    public string[] partSpeechI;
    public string[] suffix;
    private List<string> wordsN = new List<string>();
    private List<float> pointsN = new List<float>();
    private List<string> wordsA = new List<string>();
    private List<float> pointsA = new List<float>();
    private List<string> suffixL = new List<string>();
    public GameObject prefab;
    public GameObject lineOBJ;
    private Vector2 position;
    public int BPM;
    public int speed;
    public void Start()
    {
        // Sorts the words into nouns and adjectives.
        for(int i = 0; i < words.Length; i++)
        {
            if (partSpeechI[i] == "Noun")
            {
                wordsN.Add(words[i]);
                pointsN.Add(points[i]);
            }
            else if (partSpeechI[i] == "ADJ")
            {
                wordsA.Add(words[i]);
                pointsA.Add(points[i]);
            }
            suffixL.Add(suffix[i]);
        }
    }
    public void createWord(int numWords, string POS, bool append)
    {
        // This loop is repeated a number of times equal to the amount called for.
        for (int i = 0; i < numWords; i++)
        {
            // Will sacrifice the lack of duplicates to stop a crash if need be.
            if(wordsN.Count == 0 || wordsA.Count == 0)
            {
                reShuffleWords();
            }
            // Generates a random float within a range onscreen.
            float x = Random.Range(-5f, 5f);
            float y = Random.Range(0f, 4f);
            position.x = x;
            position.y = y;
            // Creates a clone with the position taken from the floats.
            var clone = Instantiate(prefab, position, Quaternion.identity);
            // Grabs the moveRandomlyOnBeat from a clone and modifies it.
            moveRandomlyOnBeat clonebeat = clone.GetComponent<moveRandomlyOnBeat>();
            clonebeat.beatsPerMinute = BPM;
            clonebeat.speed = speed;
            // Generates a random word and it's point value and attaches it to the word.
            int rand = Random.Range(0, wordsN.Count);
            string word = "";
            float point = 0.0f;
            // Checks if the word is a noun or adjective and adjusts accordingly.
            if (POS == "Noun")
            {
                word = wordsN[rand];
                point = pointsN[rand];
                if (append)
                {
                    print("append entered");
                    word = word + suffixL[rand];
                    suffixL.RemoveAt(rand);
                }
                wordsN.RemoveAt(rand);
                pointsN.RemoveAt(rand);
            }
            else
            {
                word = wordsA[rand];
                point = pointsA[rand];
                if (append)
                {
                    print("append entered");
                    word = word + suffixL[rand];
                    suffixL.RemoveAt(rand);
                }
                wordsA.RemoveAt(rand);
                pointsA.RemoveAt(rand);
            }
            string PSI = POS;
            WordCustomizer obj = clone.GetComponent<WordCustomizer>();
            obj.selfUpdate(word, point, PSI);
            }
        // Creates the linepointer object.
        Instantiate(lineOBJ);
        reShuffleWords();
    }
    public void reShuffleWords()
    {
        // Clears the current word list to prepare to re-apply them all again.
        wordsN.Clear();
        pointsN.Clear();
        wordsA.Clear();
        pointsA.Clear();
        suffixL.Clear();
        // Sorts the words into nouns and adjectives.
        for (int i = 0; i < words.Length; i++)
        {
            if (partSpeechI[i] == "Noun")
            {
                wordsN.Add(words[i]);
                pointsN.Add(points[i]);
            }
            else if (partSpeechI[i] == "ADJ")
            {
                wordsA.Add(words[i]);
                pointsA.Add(points[i]);
            }
            suffixL.Add(suffix[i]);
        }
    }
}
