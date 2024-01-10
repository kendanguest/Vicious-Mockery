using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBlip : MonoBehaviour
{
    public AudioSource AudioSource;
    public AudioClip MC1;
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
        if (cha == 1)
        {
            AudioSource.Play(MC1);
        }
        else
        {

        }

    }
}
