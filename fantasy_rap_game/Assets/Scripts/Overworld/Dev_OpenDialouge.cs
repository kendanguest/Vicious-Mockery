using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dev_OpenDialouge : MonoBehaviour
{
    public DialogueDisplay dialogue;
    public wordRandomizer random;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            dialogue.DisplayDialogue(dialogue.currentDialogue);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            dialogue.inputUpdate("Bruh");
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            random.createWord(3);
        }
    }
    
}
