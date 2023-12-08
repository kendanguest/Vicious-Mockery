/*
 * Name: Jackson Miller
 * Date: 12/7/23
 * Desc: Manages which jukebox is active.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioSource jukebox1;
    public AudioSource jukebox2;
    // Start is called before the first frame update
    void Start()
    {
    }

    //Switches from jukebox 1 to jukebox 2.
    public void jukeboxSwitch()
    {
        jukebox1.Stop();
        jukebox2.Play();
    }
    public void jukeboxSwitchBack()
    {
        jukebox2.Stop();
        jukebox1.Play();
    }
}
