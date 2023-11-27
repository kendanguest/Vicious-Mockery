/*
 * Name: Jackson Miller
 * Date: 10/2/23
 * Desc: Attach to an object to give it health and the abilty to die at zero health. Used by DamageOnCollide.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth = 3;
    public bool destroyAtZero = true;
    public float destroyDelay = 0.0f;

    public UnityEvent onDamage;
    public UnityEvent onHeal;
    public UnityEvent onDestroy;

    // Pretty self explanatory.
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        onDamage.Invoke();
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        if(currentHealth == 0 && destroyAtZero)
        {
            onDestroy.Invoke();
            Destroy(gameObject, destroyDelay);
        }
    }

    public void HealDamage(int healing)
    {
        currentHealth += healing;
        onHeal.Invoke();
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}
