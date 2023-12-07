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

    public void startDodgeGame(int bTT, int bpm)
    {
        var clone = Instantiate(prefab);
        DamageMitigationCheck DMC = clone.GetComponentInChildren<DamageMitigationCheck>();
        DMC.selfUpdate(bpm, bTT);
    }
}
