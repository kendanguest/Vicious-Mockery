/*
 * Name: Jackson Miller
 * Date: 2/26/23
 * Desc: Runs all the Dialogue for level 2 in a sequence.
 */
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Level2Runner : MonoBehaviour
{
    public DialogueDisplay dialogue;
    public GameObject UI;
    public DialogueObject prefightDialogue;
    public DialogueObject trueRap;
    public DialogueObject postRapW;
    public wordRandomizer random;
    public RapShadowController RSC;
    public SpawnDodgeMinigame SDM;
    public MusicController MusicController;
    public bool progress;
    public int line;
    public pointsArrow arrow;
    public TransitionBehavior transition;
    public GenerateNote gnote;
    public MenuFunctions menuFunctions;
    public TMP_Text getReady;
    private int denom = 140;
    private float beat = 60f / 140f;
    // Start is called before the first frame update
    void Start()
    {
        // This starts the Coroutine.
        SDM = FindObjectOfType<SpawnDodgeMinigame>();
        getReady.text = "";
        UI.SetActive(false);
        dialogue.currentDialogue = prefightDialogue;
        StartCoroutine(Startlevel());
    }

    IEnumerator Startlevel()
    {
        // This is exactly the same thing as done in level 1. Fun.
        line = 0;
        yield return new WaitForSeconds(1f);
        dialogue.DisplayDialogue(prefightDialogue);
        UI.SetActive(true);
        yield return new WaitUntil(() => (progress == true));
        UI.SetActive(true);
        progress = false;
        line = 0;
        dialogue.currentDialogue = trueRap;
        trueRap.BPM = denom;
        MusicController.jukeboxSwitch();
        getReady.text = "Get Ready!";
        yield return new WaitForSecondsRealtime(beat * 16);
        getReady.text = "";
        dialogue.DisplayDialogue(trueRap);
        yield return new WaitUntil(() => line == 0);
        newPlayerTurn(line, "Noun", false);
        yield return new WaitUntil(() => line == 1);
        newPlayerTurn(line, "ADJ", false);
        yield return new WaitUntil(() => line == 2);
        newPlayerTurn(line, "Noun", false);
        yield return new WaitUntil(() => line == 3);
        speedup(20);
        newEnemyTurn(line, denom, "thrifted");
        yield return new WaitUntil(() => line == 4);
        newEnemyTurn(line, denom, "muck");
        yield return new WaitUntil(() => line == 5);
        newEnemyTurn(line, denom, "uplifted");
        yield return new WaitUntil(() => line == 6);
        newEnemyTurn(line, denom, "guck");
        yield return new WaitUntil(() => line == 7);
        speedup(20);
        newPlayerTurn(line, "Noun", false);
        yield return new WaitUntil(() => line == 8);
        newPlayerTurn(line, "Noun", false);
        yield return new WaitUntil(() => line == 9);
        newPlayerTurn(line, "ADJ", false);
        yield return new WaitUntil(() => line == 10);
        newPlayerTurn(line, "ADJ", false);
        yield return new WaitUntil(() => line == 11);
        speedup(20);
        newEnemyTurn(line, denom, "class");
        yield return new WaitUntil(() => line == 12);
        newEnemyTurn(line, denom, "hand");
        yield return new WaitUntil(() => line == 13);
        newEnemyTurn(line, denom, "pass");
        yield return new WaitUntil(() => line == 14);
        newEnemyTurn(line, denom, "command");
        yield return new WaitUntil(() => (progress == true));
        UI.SetActive(true);
        progress = false;
        line = 0;
        MusicController.jukeboxSwitchBack();
        dialogue.DisplayDialogue(postRapW);
        yield return new WaitUntil(() => (progress == true));
        UI.SetActive(false);
        StartCoroutine(transition.fadeIn());
        yield return new WaitForSeconds(3.5f);
        menuFunctions.sceneName = "Rap scene3";
        GetComponent<MenuFunctions>().PlayScene();
    }

    private void newPlayerTurn(int line, string type, bool append)
    {
        // Updates the shadow line and creates the words needed.
        RSC.shadowRap(line);
        random.createInsult(7, type, append);
        random.createCompliment(2, type, append);
    }
    private void newEnemyTurn(int line, int bpm, string insultWord)
    {
        // Updates the shadow line and spawns the dodge minigame.
        RSC.shadowRap(line);
        SDM.startDodgeGame(bpm, bpm*3, insultWord);
    }
    private void speedup(int am)
    {
        denom += am;
        beat = 60f / denom;
        random.BPM += am;
        gnote.BPM += am;
        trueRap.BPM += am;
    }
    
    }
