/*
 * Name: Jackson Miller
 * Date: 12/8/23
 * Desc: This script is stupid, but it had to be this way, it just updates the text on the moving object.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class recieveTextData : MonoBehaviour
{
    public TMP_Text text;

    public void recieveText(string textO)
    {
        text.text = textO;
    }
}
