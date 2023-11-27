/*
 * Name: Jackson Miller
 * Date: 10/2/23
 * Desc: Attach to an object to make it deal damage on collision. Uses Health.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnCollide : MonoBehaviour
{
    public int damage = 1;

    // Covers both types of collision using these two functions.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Health health = collision.gameObject.GetComponent<Health>();
        if(health != null)
        {
            if(damage > 0)
                health.TakeDamage(damage);
            else
                health.HealDamage(damage);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health health = collision.gameObject.GetComponent<Health>();
        if (health != null)
        {
            if (damage > 0)
                health.TakeDamage(damage);
            else
                health.HealDamage(damage);
        }
    }
}
