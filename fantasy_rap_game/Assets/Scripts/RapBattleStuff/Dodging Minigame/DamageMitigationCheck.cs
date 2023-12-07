using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DamageMitigationCheck : MonoBehaviour
{
    public int bpm;
    public int beatsTillTrigger;
    public float damageOnHit;
    public float damageOnDodge;
    public pointsArrow meter;
    private float timeUntilHit;
    private bool isCurrentlyDodging;
    public GameObject fibacheHead;
    public GameObject parent;
    private float totalTime = 0;

    void Start()
    {
        timeUntilHit = ( 60f/bpm) * beatsTillTrigger+(60f/bpm)/2;
        meter = FindObjectOfType<pointsArrow>();
    }

    // Update is called once per frame
    void Update()

    {
        totalTime += Time.deltaTime;
        if (totalTime >= timeUntilHit)
        {
            if (isCurrentlyDodging)
            {
                meter.points -= damageOnDodge;

            }
            else
            {
                meter.points -= damageOnHit;

            };

            Destroy(parent);
        };
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isCurrentlyDodging = false;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
         isCurrentlyDodging = true;
    }

    public void selfUpdate(int bpmO, int bTTO)
    {
        bpm = bpmO;
        beatsTillTrigger = bTTO;
    }

}
