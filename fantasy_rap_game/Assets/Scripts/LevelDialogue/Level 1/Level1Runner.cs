/*
 * Name: Jackson Miller
 * Date: 12/4/23
 * Desc: Runs all the Dialogue for level 1 in a sequence.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Level1Runner : MonoBehaviour
{
    public DialogueDisplay dialogue;
    public GameObject UI;
    public DialogueObject prefightDialogue;
    public DialogueObject tutorial_1;
    public DialogueObject rap1;
    public DialogueObject tutorial_2;
    public DialogueObject rap2;
    public DialogueObject bridge;
    public DialogueObject trueRap;
    public DialogueObject postRapW;
    public DialogueObject postRapL;
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
    public PlayBlip blip;
    public AudioClip clock120;
    // Start is called before the first frame update
    void Start()
    {
        // This starts the Coroutine.
        SDM = FindObjectOfType<SpawnDodgeMinigame>();
        getReady.text = "";
        UI.SetActive(false);
        dialogue.currentDialogue = prefightDialogue;
        StartCoroutine(Startlevel());
        blip.clock = clock120;
    }
    IEnumerator Startlevel()
    {
        // This IEnumerator controls when the dialogue spawns.
        // This code looks like YandereDev programmed it, but it's as we say in the buisness, "it functions."
        float beat = 60f / 180f;
        line = 0;
        yield return new WaitForSeconds(6f);
        dialogue.DisplayDialogue(prefightDialogue);
        UI.SetActive(true);
        yield return new WaitUntil(() => (progress == true));
        UI.SetActive(true);
        progress = false;
        dialogue.currentDialogue = tutorial_1;
        dialogue.DisplayDialogue(tutorial_1);
        yield return new WaitUntil(() => (progress == true));
        UI.SetActive(true);
        progress = false;
        dialogue.currentDialogue = rap1;
        dialogue.DisplayDialogue(rap1);
        random.speed = 10;
        gnote.speed = 10;
        yield return new WaitUntil(() => line == 0);
        newPlayerTurn(line, "ADJ", true);
        yield return new WaitUntil(() => line == 1);
        newPlayerTurn(line, "ADJ", true);
        yield return new WaitUntil(() => line == 2);
        newPlayerTurn(line, "Noun", false);
        yield return new WaitUntil(() => line == 3);
        newPlayerTurn(line, "Noun", false);
        yield return new WaitUntil(() => (progress == true));
        UI.SetActive(true);
        progress = false;
        line = 0;
        dialogue.currentDialogue = tutorial_2;
        dialogue.DisplayDialogue(tutorial_2);
        yield return new WaitUntil(() => (progress == true));
        UI.SetActive(true);
        progress = false;
        line = 0;
        dialogue.currentDialogue = rap2;
        dialogue.DisplayDialogue(rap2);
        yield return new WaitUntil(() => line == 0);
        newEnemyTurn(line, 120, "heat");
        yield return new WaitUntil(() => line == 1);
        newEnemyTurn(line, 120, "beat");
        yield return new WaitUntil(() => line == 2);
        newEnemyTurn(line, 120, "tear");
        yield return new WaitUntil(() => line == 3);
        newEnemyTurn(line, 120, "hear");
        yield return new WaitUntil(() => (progress == true));
        UI.SetActive(true);
        progress = false;
        line = 0;
        dialogue.currentDialogue = bridge;
        dialogue.DisplayDialogue(bridge);
        yield return new WaitUntil(() => (progress == true));
        getReady.text = "Get Ready!";
        UI.SetActive(true);
        progress = false;
        line = 0;
        dialogue.currentDialogue = trueRap;
        MusicController.jukeboxSwitch();
        random.speed = 100;
        gnote.speed = 100;
        dialogue.forceTooltipchange(false);
        yield return new WaitForSecondsRealtime(beat * 32);
        getReady.text = "";
        dialogue.DisplayDialogue(trueRap);
        yield return new WaitUntil(() => line == 0);
        newEnemyTurn(line, 180, "up");
        yield return new WaitUntil(() => line == 1);
        newEnemyTurn(line, 180, "enough");
        yield return new WaitUntil(() => line == 2);
        newEnemyTurn(line, 180, "goodbye");
        yield return new WaitUntil(() => line == 3);
        newEnemyTurn(line, 180, "class");
        yield return new WaitUntil(() => line == 4);
        newEnemyTurn(line, 180, "glass");
        yield return new WaitUntil(() => line == 5);
        newPlayerTurn(line, "Noun", false);
        yield return new WaitUntil(() => line == 6);
        newPlayerTurn(line, "ADJ", false);
        yield return new WaitUntil(() => line == 7);
        newPlayerTurn(line, "Noun", false);
        yield return new WaitUntil(() => line == 8);
        newPlayerTurn(line, "ADJ", false);
        yield return new WaitUntil(() => line == 9);
        newPlayerTurn(line, "Noun", false);
        yield return new WaitUntil(() => line == 10);
        newEnemyTurn(line, 180, "start");
        yield return new WaitUntil(() => line == 11);
        newEnemyTurn(line, 180, "apart");
        yield return new WaitUntil(() => line == 12);
        newEnemyTurn(line, 180, "champion");
        yield return new WaitUntil(() => line == 13);
        newEnemyTurn(line, 180, "alien");
        yield return new WaitUntil(() => line == 14);
        newPlayerTurn(line, "ADJ", false);
        yield return new WaitUntil(() => line == 15);
        newPlayerTurn(line, "ADJ", false);
        yield return new WaitUntil(() => line == 16);
        newPlayerTurn(line, "ADJ", false);
        yield return new WaitUntil(() => line == 17);
        newPlayerTurn(line, "ADJ", false);
        yield return new WaitUntil(() => (progress == true));
        UI.SetActive(true);
        progress = false;
        line = 0;
        MusicController.jukeboxSwitchBack();
        if (arrow.points > 10)
        {
            dialogue.currentDialogue = postRapW;
            dialogue.DisplayDialogue(postRapW);
            menuFunctions.sceneName = "Rap scene2";
            transition.aftertext = "Fibache leaves the classroom triumphant...";
        }
        else
        {
            dialogue.currentDialogue = postRapL;
            dialogue.DisplayDialogue(postRapL);
            menuFunctions.sceneName = "TempMenu";
            transition.aftertext = "Fibache returns home defeated...";
        }
        yield return new WaitUntil(() => (progress == true));
        UI.SetActive(false);
        StartCoroutine(transition.fadeIn());
        yield return new WaitForSeconds(8.5f);
        GetComponent<MenuFunctions>().PlayScene();
    }

    private void newPlayerTurn(int line, string type, bool append)
    {
        // Updates the shadow line and creates the words needed.
        RSC.shadowRap(line);
        random.createInsult(7, type, append);
        random.createCompliment(2, type, append);
    }
    private void newEnemyTurn(int line,int bpm, string insultWord)
    {
        // Updates the shadow line and spawns the dodge minigame.
        RSC.shadowRap(line);
        SDM.startDodgeGame(bpm, bpm*3, insultWord);
    }
}