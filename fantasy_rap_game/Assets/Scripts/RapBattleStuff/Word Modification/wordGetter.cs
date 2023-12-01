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
        currentWord = pointer.GetComponent<wordSelector>().closestWord;
        print(pointer.GetComponent<wordSelector>().closestWord);
        if (Input.GetMouseButtonDown(0))
        {
            text.inputUpdate(currentWord.name);
        };
    }

    public void updateLine(GameObject newPointer)
    {
        pointer = newPointer;
    }
}
