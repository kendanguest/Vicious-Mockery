/*
 *August Rossano (And the Header author)
 *LED:11/30/23
 *DESC: Allows player to click on words
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wordGetter : MonoBehaviour
{
    public DialogueDisplay text;
    public GameObject pointer;
    public GameObject currentWord;
    public GameObject lastClickedWord;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //if like it uh it it checks and syas "i'm looking at this word" and other scripts can see
    void Update()
    {
        if(pointer != null)
        {
            currentWord = pointer.GetComponent<wordSelector>().closestWord;
            if (Input.GetMouseButtonDown(0))
            {
                lastClickedWord = currentWord;
                text.inputUpdate(lastClickedWord.GetComponent<WordCustomizer>().wordO);
            }
        }
    }

    public void updateLine(GameObject newPointer)
    {
        pointer = newPointer;
    }
}
