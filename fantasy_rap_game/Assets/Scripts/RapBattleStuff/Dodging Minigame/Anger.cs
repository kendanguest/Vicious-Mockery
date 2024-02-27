using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Anger : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject happyFace;
    public GameObject angryFace;


    void Start()
    {
        angryFace.SetActive(false);
    }

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<SpriteRenderer>() != null)
        {
            angryFace.SetActive(true);
            happyFace.SetActive(false);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<SpriteRenderer>() != null)
        {
            angryFace.SetActive(false);
            happyFace.SetActive(true);
        }
    }
}
