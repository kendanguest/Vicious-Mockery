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
    public GameObject prefab;
    private Vector2 position;
    public void createWord(int numWords)
    {
        for(int i = 0; i < numWords; i++)
        {
            float x = Random.Range(-10f, 10f);
            float y = Random.Range(0f, 10f);
            position.x = x;
            position.y = y;
            var clone = Instantiate(prefab, position, Quaternion.identity);
        }
    }
}
