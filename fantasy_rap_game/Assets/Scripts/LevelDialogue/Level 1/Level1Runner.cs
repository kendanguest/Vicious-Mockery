/*
 * Name: Jackson Miller
 * Date: 12/4/23
 * Desc: Runs all the Dialogue for level 1 in a sequence.
 */
using System.Collections;
using System.Collections.Generic;
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
    public ComplimentRandomizer Crandom;
    public RapShadowController RSC;
    public SpawnDodgeMinigame SDM;
    public MusicController MusicController;
    public bool progress;
    public int line;
    public pointsArrow arrow;
    // Start is called before the first frame update
    void Start()
    {
        // This starts the Coroutine.
        SDM = FindObjectOfType<SpawnDodgeMinigame>();
        UI.SetActive(false);
        dialogue.currentDialogue = prefightDialogue;
        dialogue.DisplayDialogue(prefightDialogue);
        StartCoroutine(startlevel());
    }
    IEnumerator startlevel()
    {
        // This IEnumerator controls when the dialogue spawns.
        // 312 beats 180 BPM.
        // This code looks like YandereDev programmed it, but it's as we say in the buisness, "it functions."
        line = 0;
        yield return new WaitForSeconds(1);
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
        yield return new WaitUntil(() => line == 0);
        newPlayerTurn(line, "ADJ");
        yield return new WaitUntil(() => line == 1);
        newPlayerTurn(line, "ADJ");
        yield return new WaitUntil(() => line == 2);
        newPlayerTurn(line, "Noun");
        yield return new WaitUntil(() => line == 3);
        newPlayerTurn(line, "ADJ");
        yield return new WaitUntil(() => (progress == true));
        UI.SetActive(true);
        progress = false;
        line = 0;
        dialogue.currentDialogue = tutorial_2;
        dialogue.DisplayDialogue(tutorial_2);
        yield return new WaitUntil(() => (progress == true));
        UI.SetActive(true);
        progress = false;
        dialogue.currentDialogue = rap2;
        dialogue.DisplayDialogue(rap2);
        yield return new WaitUntil(() => line == 0);
        newEnemyTurn(line, 7, 120);
        yield return new WaitUntil(() => line == 1);
        newEnemyTurn(line, 6, 120);
        yield return new WaitUntil(() => line == 2);
        newEnemyTurn(line, 10, 120);
        yield return new WaitUntil(() => line == 3);
        newEnemyTurn(line, 12, 120);
        yield return new WaitUntil(() => (progress == true));
        UI.SetActive(true);
        progress = false;
        line = 0;
        dialogue.currentDialogue = bridge;
        dialogue.DisplayDialogue(bridge);
        yield return new WaitUntil(() => (progress == true));
        UI.SetActive(true);
        progress = false;
        dialogue.currentDialogue = trueRap;
        MusicController.jukeboxSwitch();
        dialogue.DisplayDialogue(trueRap);
        yield return new WaitUntil(() => line == 0);
        newEnemyTurn(line, 7, 120);
        yield return new WaitUntil(() => line == 1);
        newEnemyTurn(line, 6, 120);
        yield return new WaitUntil(() => line == 2);
        newEnemyTurn(line, 6, 120);
        yield return new WaitUntil(() => line == 3);
        newEnemyTurn(line, 6, 120);
        yield return new WaitUntil(() => line == 4);
        newEnemyTurn(line, 6, 120);
        yield return new WaitUntil(() => line == 5);
        newPlayerTurn(line, "ADJ");
        yield return new WaitUntil(() => line == 6);
        newPlayerTurn(line, "ADJ");
        yield return new WaitUntil(() => line == 7);
        newPlayerTurn(line, "Noun");
        yield return new WaitUntil(() => line == 8);
        newPlayerTurn(line, "ADJ");
        yield return new WaitUntil(() => line == 9);
        newPlayerTurn(line, "Noun");
        yield return new WaitUntil(() => line == 10);
        newEnemyTurn(line, 6, 120);
        yield return new WaitUntil(() => line == 11);
        newEnemyTurn(line, 6, 120);
        yield return new WaitUntil(() => line == 12);
        newEnemyTurn(line, 6, 120);
        yield return new WaitUntil(() => line == 13);
        newEnemyTurn(line, 6, 120);
        yield return new WaitUntil(() => line == 14);
        newPlayerTurn(line, "ADJ");
        yield return new WaitUntil(() => line == 15);
        newPlayerTurn(line, "ADJ");
        yield return new WaitUntil(() => line == 16);
        newPlayerTurn(line, "ADJ");
        yield return new WaitUntil(() => line == 17);
        newPlayerTurn(line, "ADJ");
        yield return new WaitUntil(() => (progress == true));
        UI.SetActive(true);
        progress = false;
        line = 0;
        if (arrow.points > 10)
        {
            dialogue.currentDialogue = postRapW;
            dialogue.DisplayDialogue(postRapW);
        }
        else
        {
            dialogue.currentDialogue = postRapL;
            dialogue.DisplayDialogue(postRapL);
        }
        GetComponent<MenuFunctions>().PlayScene();
    }

    private void newPlayerTurn(int line, string type)
    {
        // Updates the shadow line and creates the words needed.
        RSC.shadowRap(line);
        random.createWord(7, type);
        Crandom.createCompliment(2, type);
    }
    private void newEnemyTurn(int line, int beats, int bpm)
    {
        RSC.shadowRap(line);
        SDM.startDodgeGame(beats, bpm);
    }
}