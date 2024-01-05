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
    public WordObject[] compliments;
    private List<WordObject> complimentsN = new List<WordObject>();
    private List<WordObject> complimentsA = new List<WordObject>();
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
        for(int i = 0; i < compliments.Length; i++)
        {
            if (compliments[i].partOfSpeech == "Noun")
            {
                complimentsN.Add(compliments[i]);
            }
            else if (compliments[i].partOfSpeech == "ADJ")
            {
                complimentsA.Add(compliments[i]);
            }
        }
    }
    public void createWord(int numWords, string POS, bool append, int type)
    {
        // This loop is repeated a number of times equal to the amount called for.
        for (int i = 0; i < numWords; i++)
        {
            if(type == 1)
            {
                // Will sacrifice the lack of duplicates to stop a crash if need be.
                if (wordsN.Count == 0 || wordsA.Count == 0)
                {
                    reShuffleWords(1);
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
                    // Checks if the suffix needs to be appended to the end of the word.
                    if (append)
                    {
                        word = wordsN[rand].word + wordsN[rand].suffix;
                    }
                    else
                    {
                        word = wordsN[rand].word;
                    }
                    // Removes the word from the list after it gets used once.
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
                    {
                        word = wordsA[rand].word;
                    }
                    // Removes the word from the list after it gets used once.
                    wordsA.RemoveAt(rand);
                }
                string PSI = POS;
                WordCustomizer obj = clone.GetComponent<WordCustomizer>();
                obj.selfUpdate(word, point, PSI);
            }
            else if(type == 2)
            {
                // Will sacrifice the lack of duplicates to stop a crash if need be.
                if (complimentsN.Count == 0 || complimentsA.Count == 0)
                {
                    reShuffleWords(2);
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
                    rand = Random.Range(0, complimentsN.Count);
                }
                else
                {
                    rand = Random.Range(0, complimentsA.Count);
                }
                string word = "";
                float point = 0.0f;
                // Checks if the word is a noun or adjective and adjusts accordingly.
                if (POS == "Noun")
                {
                    point = complimentsN[rand].points;
                    // Checks if the suffix needs to be appended to the end of the word.
                    if (append)
                    {
                        word = complimentsN[rand].word + complimentsN[rand].suffix;
                    }
                    else
                    {
                        word = complimentsN[rand].word;
                    }
                    // Removes the word from the list after it gets used once.
                    complimentsN.RemoveAt(rand);
                }
                else
                {
                    point = complimentsA[rand].points;

                    if (append)
                    {
                        word = complimentsA[rand].word + complimentsA[rand].suffix;
                    }
                    else
                    {
                        word = complimentsA[rand].word;
                    }
                    // Removes the word from the list after it gets used once.
                    complimentsA.RemoveAt(rand);
                }
                string PSI = POS;
                WordCustomizer obj = clone.GetComponent<WordCustomizer>();
                obj.selfUpdate(word, point, PSI);
            }
        }
    
    }

    // This specifically creates insults
    public void createInsult(int numWords, string POS, bool append)
    {
        createWord(numWords, POS, append, 1);
        // Creates the linepointer object.
        Instantiate(lineOBJ);
        reShuffleWords(1);
    }
    // This specifically creates compliments
    public void createCompliment(int numWords, string POS, bool append)
    {
        createWord(numWords, POS, append, 2);
        reShuffleWords(2);
    }
    // This will reShuffle all the words back into the list, 1 is insults, 2 is compliments.
    public void reShuffleWords(int type)
    {
        if(type == 1)
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
        else if (type == 2)
        {
            // Clears the current word list to prepare to re-apply them all again.
            complimentsN.Clear();
            complimentsA.Clear();
            // Sorts the words into nouns and adjectives.
            for (int i = 0; i < compliments.Length; i++)
            {
                if (compliments[i].partOfSpeech == "Noun")
                {
                    complimentsN.Add(compliments[i]);
                }
                else if (compliments[i].partOfSpeech == "ADJ")
                {
                    complimentsA.Add(compliments[i]);
                }
            }
        }
    }
}
