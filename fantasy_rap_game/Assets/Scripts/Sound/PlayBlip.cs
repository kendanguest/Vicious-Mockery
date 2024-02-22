using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBlip : MonoBehaviour
{
    public AudioSource AudioSource;
    public AudioClip MC1;
    public AudioClip MC2;
    public AudioClip MC3;
    public AudioClip MC4;
    public AudioClip PR1;
    public AudioClip PR2;
    public AudioClip PR3;
    public AudioClip PR4;
    public AudioClip clock;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playBlip(int cha)
    {
        int i = Random.Range(1, 4);
        if (cha == 1)
        {
            if (i == 1)
            {
                AudioSource.PlayOneShot(MC1);
            }
            else if (i == 2)
            {
                AudioSource.PlayOneShot(MC2);
            }
            else if (i == 3)
            {
                AudioSource.PlayOneShot(MC3);
            }
            else
            {
                AudioSource.PlayOneShot(MC4);
            }
        }
        else
        {
            if (i == 1)
            {
                AudioSource.PlayOneShot(PR1);
            }
            else if (i == 2)
            {
                AudioSource.PlayOneShot(PR2);
            }
            else if (i == 3)
            {
                AudioSource.PlayOneShot(PR3);
            }
            else
            {
                AudioSource.PlayOneShot(PR4);
            }
        }

    }
    public void playClock()
    {
        AudioSource.PlayOneShot(clock);
    }
}
