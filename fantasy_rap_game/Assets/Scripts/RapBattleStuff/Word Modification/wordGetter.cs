/*
 *August Rossano (And the Header author)
 *LED:11/30/23
 *DESC:
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wordGetter : MonoBehaviour
{
    public DialogueDisplay text;
    public GameObject pointer;
    public GameObject currentWord;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(pointer != null)
        {
            currentWord = pointer.GetComponent<wordSelector>().closestWord;
            if (Input.GetMouseButtonDown(0))
            {
                text.inputUpdate(currentWord.GetComponent<WordCustomizer>().wordO);
            }
        }
    }

    public void updateLine(GameObject newPointer)
    {
        pointer = newPointer;
    }
}
