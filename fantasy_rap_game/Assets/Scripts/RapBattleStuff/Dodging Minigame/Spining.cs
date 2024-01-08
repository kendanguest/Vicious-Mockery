using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//August Rossano
//12-11-23
//makes things spin on beat
public class Spining : MonoBehaviour
{
    public int beatsPerMinute;
    private float beatInterval;
    private float timeInBeat;
    private float lastTimeInBeat;
    private Rigidbody2D rb;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        beatInterval = 60f / beatsPerMinute;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        lastTimeInBeat = timeInBeat;
        timeInBeat = (Time.fixedUnscaledTime % beatInterval) / (beatsPerMinute / 60f);

        if (timeInBeat < lastTimeInBeat)
        {
            rb.angularVelocity = 0;
        };
        //moves like a clock
        rb.angularVelocity += Time.deltaTime * Mathf.Cos(Mathf.PI * (timeInBeat)) *speed;
       

    }


   
}
