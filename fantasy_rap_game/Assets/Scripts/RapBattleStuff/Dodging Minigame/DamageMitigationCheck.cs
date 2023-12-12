using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DamageMitigationCheck : MonoBehaviour
{
    public int bpm;
    public float damageOnHit;
    public float damageOnDodge;
    public pointsArrow meter;
    private bool isCurrentlyDodging;
    public GameObject fibacheHead;
    public GameObject parent;
    private bool terminate;

    void Start()
    {
        terminate = false;
        meter = FindObjectOfType<pointsArrow>();
    }

    // Update is called once per frame
    void Update()

    {
        
        if (terminate)
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

    public void selfUpdate(int bpmO)
    {
        bpm = bpmO;
    }

    public void terminateMinigame()
    {
        terminate = true;
    }

}
