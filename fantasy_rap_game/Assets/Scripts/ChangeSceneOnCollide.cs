/*
 * Name: Jackson Miller
 * Date: 10/3/23
 * Desc: Add this to an object you want to change the current scene when touched by a object on a specific layer collides.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnCollide : MonoBehaviour
{
    public string sceneName = "MainMenu";
    public LayerMask acceptedLayers;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Very odd code, uses bit manipulation to shift the binary value over by using fusion??? (00001111 | 11110000 = 11111111).
        if(acceptedLayers == (acceptedLayers | (1 << collision.gameObject.layer)))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Very odd code, uses bit manipulation to shift the binary value over by using fusion??? (00001111 | 11110000 = 11111111).
        if (acceptedLayers == (acceptedLayers | (1 << collision.gameObject.layer)))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
