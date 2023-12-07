/*
 * Name: Jackson Miller
 * Date: 12/7/23
 * Desc: Attached to runner prefabs to get a list of all word objects onscreen and then kill them on call.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDodgeMinigame : MonoBehaviour
{
    public GameObject prefab;
    private DamageMitigationCheck DMC;
    public int bpm;

    public void startDodgeGame(int bTT)
    {
        var clone = Instantiate(prefab);
        DMC = clone.GetComponent<DamageMitigationCheck>();
        DMC.bpm = bpm;
        DMC.beatsTillTrigger = bTT;
    }
}
