/*
 * Name: Jackson Miller
 * Date: 10/2/23
 * Desc: Handles multiple UnityEvent misc. things
 */
using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventUtilities : MonoBehaviour
{
    public GameObject toSpawn;
    public AudioSource myAudio;

    private void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }
    public void playSFX(AudioClip soundEffect)
    {
        if(myAudio != null)
        {
            myAudio.PlayOneShot(soundEffect);
        }
    }
    public void SpawnAtPosition()
    {
        Instantiate(toSpawn, transform.position, Quaternion.identity);
    }
    public void ChangeLevel(string levelName)
    {
        SceneManager.LoadScene(levelName); 
    }
}
