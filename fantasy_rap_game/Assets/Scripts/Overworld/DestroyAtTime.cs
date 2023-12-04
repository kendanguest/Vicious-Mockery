/*
 * Name: Jackson Miller
 * Date: 9/29/23
 * Desc: Attach to an object meant to destroy itself when enough time passes.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAtTime : MonoBehaviour
{
    public float deathTime = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(killObject());
    }

    IEnumerator killObject()
    {
        yield return new WaitForSeconds(deathTime);
        Destroy(gameObject);
    }
}