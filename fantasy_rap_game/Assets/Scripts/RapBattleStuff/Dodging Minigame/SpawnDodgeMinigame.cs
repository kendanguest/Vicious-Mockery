/*
 * Name: Jackson Miller
 * Date: 12/7/23
 * Desc: Attached to runner prefabs to get a list of all word objects onscreen and then kill them on call.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnDodgeMinigame : MonoBehaviour
{
    public GameObject prefab;
    public DialogueDisplay dia;

    public void startDodgeGame(int bpm,int speed, string word)
    {
        var clone = Instantiate(prefab);
        dia.updateLookoutVar(word);
        clone.GetComponentInChildren<DamageMitigationCheck>().selfUpdate(bpm);
        clone.GetComponentInChildren<Spining>().selfUpdate(bpm, speed);
        clone.GetComponent<recieveTextData>().recieveText(word); 
    }
}
