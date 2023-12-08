/*
 * Name: Jackson Miller
 * Date: 12/6/23
 * Desc: Attached to runner prefabs to get a list of all word objects onscreen and then kill them on call.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordRemover : MonoBehaviour
{
    private GameObject[] targets;
    public void refreshAllKnownWords()
    {
        // Finds all instances of the preset tag.
        targets = GameObject.FindGameObjectsWithTag("Word");
    }
    public void destroyAllKnownWords()
    {
        // Destroys all the targets gathered before.
        for (int i = 0; i < targets.Length; i++)
        {
            Destroy(targets[i]);
        }
    }
}
