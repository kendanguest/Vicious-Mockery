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
    
    public WordObject[] words;
    private List<WordObject> wordsN = new List<WordObject>();
    private List<WordObject> wordsA = new List<WordObject>();
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
            if (words[i].partOfSpeech == "Noun")
            {
                wordsN.Add(words[i]);
            }
            else if (words[i].partOfSpeech == "ADJ")
            {
                wordsA.Add(words[i]);
            }
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
            int rand = 0;
            if (POS == "Noun")
            {
                rand = Random.Range(0, wordsN.Count);
            }
            else
            {
                rand = Random.Range(0, wordsA.Count);
            }
            string word = "";
            float point = 0.0f;
            // Checks if the word is a noun or adjective and adjusts accordingly.
            if (POS == "Noun")
            {
                point = wordsN[rand].points;
                if (append)
                {
                    word = wordsN[rand].word + wordsN[rand].suffix;
                }
                else
                    word = wordsN[rand].word;
                wordsN.RemoveAt(rand);
            }
            else
            {
                point = wordsA[rand].points;
                if (append)
                {
                    word = wordsA[rand].word + wordsA[rand].suffix;
                }
                else
                    word = wordsA[rand].word;
                wordsA.RemoveAt(rand);
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
        wordsA.Clear();
        // Sorts the words into nouns and adjectives.
        for (int i = 0; i < words.Length; i++)
        {
            if (words[i].partOfSpeech == "Noun")
            {
                wordsN.Add(words[i]);
            }
            else if (words[i].partOfSpeech == "ADJ")
            {
                wordsA.Add(words[i]);
            }
        }
    }
}
