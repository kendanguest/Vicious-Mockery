//August Rossano
//2-26-24
//In the name of the world, I shall force the hands of time to stop.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopTimeOnPause : MonoBehaviour
{
    // Start is called before the first frame update
    public KeyCode button;
    public Canvas menu;


    void Start()
    {
        menu.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(button)&&Time.timeScale==1f)
        {
            Time.timeScale = 0f;
            menu.enabled = true;
        }
        else if (Input.GetKeyDown(button)&&Time.timeScale==0f)
        {
            Time.timeScale=1f;
            menu.enabled = false;
            
        }

    }
}
