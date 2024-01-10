using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

//August Rossano
//12-11-23
//Tells other parts of the game is the player got hit

public class DamageMitigationCheck : MonoBehaviour
{
    public int bpm;
    public float damageOnHit;
    public float damageOnDodge;
    public pointsArrow meter;
    public PointsUIController PUI;
    private bool isCurrentlyDodging;
    public GameObject fibacheHead;
    public GameObject parent;
    private bool terminate;

    void Start()
    {
        terminate = false;
        meter = FindObjectOfType<pointsArrow>();
        PUI = FindObjectOfType<PointsUIController>();
    }

    // Update is called once per frame
    void Update()

    {
        
        if (terminate)
        {
            if (isCurrentlyDodging)
            {
                meter.points -= damageOnDodge;
                PUI.displayPointChange(damageOnDodge, new List<int>(), "");

            }
            else
            {
                meter.points -= damageOnHit;
                PUI.displayPointChange(damageOnHit, new List<int>(), "");
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
