using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//August Rossano
//1-10-24
//J U I C E
public class PoppingAnimation : MonoBehaviour
{
    public bool reset;
    public bool dontStartOnSpawn;
    public float speed=2;
    public float duration = 2;
    public float RotationIntensity=10;
    public float ScaleIntensity=10;
    private float ScaleMod;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        if (dontStartOnSpawn)
            time = 1.1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (reset)
        {
            time = 0f;
            reset = false;
        };
        if (time*duration <= 1+Mathf.Epsilon)
        {
            transform.eulerAngles = new Vector3(0, 0,RotationIntensity * Mathf.Sin(time * Mathf.PI * speed*2));
            ScaleMod = 1  +(ScaleIntensity * Mathf.Sin(Mathf.PI* duration  *time));
            transform.localScale = new Vector3(ScaleMod, ScaleMod, 1);
            time += Time.deltaTime;
        };
    }
}
