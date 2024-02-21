/*
 * Name: Jackson Miller
 * Date: 2/21/24
 * Desc: Camera that follows the target gameobject
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GenerateNote : MonoBehaviour
{
    public Sprite[] notes;
    public GameObject prefab;
    public int BPM;
    public int speed;
    private Vector2 position;
    private int createcounter;
    // Generates 1-3 note sprites for VFX that changes based on value.
    public void generateNote(float value)
    {
        // Failsafe to prevent infinite note objects from spawning.
        createcounter = 0;
        while(value > 0f || createcounter < 3)
        {
            // Generates a note sprite within the player's range.
            float x = Random.Range(-10f, 0f);
            float y = Random.Range(0f, 4f);
            position.x = x;
            position.y = y;
            // Creates a clone copy of the prefab for modification.
            var clone = Instantiate(prefab, position, Quaternion.identity);
            clone.transform.rotation = Quaternion.Euler(0, 0, Random.Range(-15f, 15f));
            SpriteRenderer sr = clone.GetComponent<SpriteRenderer>();
            moveRandomlyOnBeat clonebeat = clone.GetComponent<moveRandomlyOnBeat>();
            clonebeat.beatsPerMinute = BPM;
            clonebeat.speed = speed;
            float rVal = Random.Range(0f, value + 3f);
            // Determines which sprite is created.
            if(rVal < 1.5f)
            {
                sr.sprite = notes[4];
            }
            else if(rVal < 3.0f)
            {
                sr.sprite = notes[3];
            }
            else if (rVal < 4.5f)
            {
                sr.sprite = notes[2];
            }
            else if (rVal < 6.0f)
            {
                sr.sprite = notes[1];
            }
            else
            {
                sr.sprite = notes[0];
            }
            createcounter++;
            value -= rVal;
        }

            
    }
}
