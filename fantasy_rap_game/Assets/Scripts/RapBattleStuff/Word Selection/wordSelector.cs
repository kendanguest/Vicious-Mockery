using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//August Rossano
//11-28-23
//Outputs the word that is being selected

public class wordSelector : MonoBehaviour
{
    private GameObject[] words;
    public GameObject closestWord;
    public GameObject self;
    private Vector3 difference;
    private Vector3 relativeMouse;
    public GameObject cameraObject;
    public GameObject getterOBJ;
    private Camera Cam;
    // Start is called before the first frame update
    void Start()
    {
        cameraObject = GameObject.FindGameObjectWithTag("MainCamera");
        getterOBJ = GameObject.FindGameObjectWithTag("Getter");
        wordGetter getter = getterOBJ.GetComponent<wordGetter>();
        getter.updateLine(self);
        words = GameObject.FindGameObjectsWithTag("Word");
        closestWord = words[0];
        Cam = cameraObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //gets the position of the mouse in the scene, this caused me to have an aneurysm
        relativeMouse = new Vector3((Input.mousePosition.x - (Screen.width / 2)) / Screen.width * Cam.aspect * Cam.orthographicSize * 2, (Input.mousePosition.y - (Screen.height / 2)) / Screen.height * Cam.orthographicSize * 2, 0);
        
        difference = closestWord.transform.position - relativeMouse;
        foreach (var word in words)
        {
            if ((word.transform.position - relativeMouse).sqrMagnitude < difference.sqrMagnitude)
            {
                closestWord = word;

            };

        }
        
        transform.position = relativeMouse;
        //makes the spotlight the right length
        transform.localScale = new Vector3(1, 1, (difference).magnitude);
        //makes the spotlight rotate the right way
        transform.rotation = Quaternion.Euler(new Vector3((Mathf.Rad2Deg * (Mathf.Atan2(-difference.y, difference.x))), 90, 0));
        
    }
}
