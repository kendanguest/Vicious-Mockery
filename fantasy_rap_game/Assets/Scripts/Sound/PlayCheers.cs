/*
 * Name: Jackson Miller
 * Date: 2/23/24
 * Desc: Plays cheers or boos depending on if you win or lose points.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayCheers : MonoBehaviour
{
    public AudioSource AudioSource;
    public AudioClip Cheer;
    public AudioClip Boo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playCheer()
    {
        AudioSource.PlayOneShot(Cheer);
    }
    public void playBoo()
    {
        AudioSource.PlayOneShot(Boo);
    }
}
