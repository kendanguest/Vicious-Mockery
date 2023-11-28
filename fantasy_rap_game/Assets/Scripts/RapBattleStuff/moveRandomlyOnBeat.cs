using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveRandomlyOnBeat : MonoBehaviour
{
    public int beatsPerMinute;
    private double beatInterval;
    private float angle;
    private double timeInTheBeat;
    
    // Start is called before the first frame update
    void Start()
    {
        beatInterval = 60/beatsPerMinute;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        timeInTheBeat = (Time.fixedUnscaledTimeAsDouble % beatInterval)/(beatsPerMinute/60);
        print(timeInTheBeat);
        

    }
}
