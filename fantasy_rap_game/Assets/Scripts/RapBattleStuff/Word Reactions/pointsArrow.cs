using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointsArrow : MonoBehaviour
{
    public float points;
    public float flickerIntensity;
    public float flickerSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles = new Vector3 (0, 0, -points+flickerIntensity*(Mathf.PerlinNoise(1,flickerSpeed * Time.time)-0.5f));
    }
}
