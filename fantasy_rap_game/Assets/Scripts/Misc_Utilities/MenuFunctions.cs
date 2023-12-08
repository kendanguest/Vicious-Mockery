/*
 * Name: Jackson Miller
 * Date: 10/3/23
 * Desc: Functions to be used by menu buttons. Potentially other unityEvents.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFunctions : MonoBehaviour
{
    public string sceneName = "Level1";
    private void Start()
    {
        Cursor.visible = true;
    }
    public void PlayScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
