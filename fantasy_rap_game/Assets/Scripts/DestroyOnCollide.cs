/*
 * Name: Jackson Miller
 * Date: 9/29/23
 * Desc: Attach to an object meant to destroy itself when it hits something.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollide : MonoBehaviour
{
    // Trigger occurs when either of the objects has a trigger collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
