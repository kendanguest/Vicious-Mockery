/*
 * Name: Jackson Miller
 * Date: 9/29/23
 * Desc: Attach to a object and select the object to fire from prefabs, will fire with mouse input.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCannon : MonoBehaviour
{
    [Tooltip("The speed the projectile is shot at.")]
    public float fireSpeed = 15.0f;
    [Tooltip("Select the prefab to fire.")]
    public GameObject toFire;
    private float timer = 0.0f;
    [Tooltip("Cooldown between shots")]
    public float cooldown = 0.5f;
    public float windUp = 0.5f;
    public AudioClip soundEffect;
    public AudioSource myAudio;
    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Figure out if we can fire a projectile, and when to fire.
        timer += Time.deltaTime;
        if (timer >= cooldown && Input.GetMouseButton(0))
        {
            FireCannon();
            timer = 0.0f;
        }
    }
    private void FireCannon()
    {
        // Edit this variable if you want an offset for the spawning location of the projectile.
        Vector3 spawnPos = transform.position;
        GameObject clone = Instantiate(toFire, spawnPos, Quaternion.identity);
        Rigidbody2D cloneRB = clone.GetComponent<Rigidbody2D>();
        StartCoroutine(SpawnedProjectile(cloneRB, windUp, fireSpeed));
        if (myAudio != null)
        {
            myAudio.PlayOneShot(soundEffect);
        }
    }

    IEnumerator SpawnedProjectile(Rigidbody2D cloneRB, float windUp, float fireSpeed)
    {
        yield return new WaitForSeconds(windUp);
        Vector3 fireDir = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        fireDir.z = transform.position.z;
        fireDir -= transform.position;
        if (cloneRB != null)
        {
            cloneRB.velocity = fireDir.normalized * fireSpeed;
        }
    }
}
