//August Rossano (and more importantly Jackson Miller)
//11-29-23
//Desc: moves on beat
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class moveRandomlyOnBeat : MonoBehaviour
{
    public int beatsPerMinute;
    private float beatInterval;
    private float angle;
    private float timeInBeat;
    private float lastTimeInBeat;
    private Rigidbody2D rb;
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        beatInterval = 60f/beatsPerMinute;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        lastTimeInBeat = timeInBeat;
        timeInBeat = (Time.fixedUnscaledTime % beatInterval)/(beatsPerMinute/60f);
        
        if (timeInBeat < lastTimeInBeat)
        {
            rb.velocity = Vector2.zero;
            angle = Random.Range(0,2*Mathf.PI);
        };
        
        rb.velocity += new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * speed * -(Mathf.Pow(timeInBeat-0.5f,3f));
            //Mathf.Cos(Mathf.PI * (timeInBeat));
    }
}
