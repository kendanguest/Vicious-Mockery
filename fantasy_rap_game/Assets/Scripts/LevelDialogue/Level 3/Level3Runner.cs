using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Runner : MonoBehaviour
{
    public DialogueDisplay dialogue;
    public GameObject UI;
    public DialogueObject prefightDialogue;
    public wordRandomizer random;
    public RapShadowController RSC;
    public SpawnDodgeMinigame SDM;
    public MusicController MusicController;
    public bool progress;
    public int line;
    public pointsArrow arrow;
    public TransitionBehavior transition;
    public GenerateNote gnote;
    // Start is called before the first frame update
    void Start()
    {
        // This starts the Coroutine.
        SDM = FindObjectOfType<SpawnDodgeMinigame>();
        UI.SetActive(false);
        dialogue.currentDialogue = prefightDialogue;
        StartCoroutine(Startlevel());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator Startlevel()
    {
        float beat = 60f / 180f;
        line = 0;
        yield return new WaitForSeconds(1f);
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
        SDM.startDodgeGame(bpm, insultWord);
    }
}
