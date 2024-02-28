/*
 * Name: Jackson Miller
 * Date: 2/26/23
 * Desc: Runs all the Dialogue for level 3 in a sequence.
 */
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Level3Runner : MonoBehaviour
{
    public DialogueDisplay dialogue;
    public GameObject UI;
    public DialogueObject prefightDialogue;
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
        float beat = 60f / 190f;
        line = 0;
        yield return new WaitForSeconds(6f);
        dialogue.DisplayDialogue(prefightDialogue);
        UI.SetActive(true);
        yield return new WaitUntil(() => (progress == true));
        UI.SetActive(true);
        progress = false;
        line = 0;
        dialogue.currentDialogue = trueRap;
        MusicController.jukeboxSwitch();
        getReady.text = "Get Ready!";
        dialogue.forceTooltipchange(false);
        yield return new WaitForSecondsRealtime(beat * 8);
        getReady.text = "";
        dialogue.DisplayDialogue(trueRap);
        yield return new WaitUntil(() => line == 0);
        newEnemyTurn(line, 190, "rhymes");
        yield return new WaitUntil(() => line == 1);
        newEnemyTurn(line, 190, "bard");
        yield return new WaitUntil(() => line == 2);
        newPlayerTurn(line, "ADJ", false);
        yield return new WaitUntil(() => line == 3);
        newPlayerTurn(line, "Noun", false);
        yield return new WaitUntil(() => line == 4);
        newEnemyTurn(line, 190, "mediocrity");
        yield return new WaitUntil(() => line == 5);
        newEnemyTurn(line, 190, "here");

        yield return new WaitUntil(() => (progress == true));
        UI.SetActive(true);
        progress = false;
        line = 0;
        dialogue.DisplayDialogue(postRapW);
        yield return new WaitUntil(() => (progress == true));
        UI.SetActive(false);
        StartCoroutine(transition.fadeIn());
        yield return new WaitForSeconds(8.5f);
        menuFunctions.sceneName = "TempMenu";
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
}
