using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGameManager : MonoBehaviour
{
    public static int playerScore1 = 0;
    public static int playerScore2 = 0;

    public GUISkin theSkin;

    public static void Score(string wallName) {
        if (wallName == "rightWall") {
            playerScore1++;
        } else {
            playerScore2++;
        }

        Debug.Log("Player score1: "+playerScore1);
        Debug.Log("Player score2: "+playerScore2);
    }
    private void OnGUI() {
        GUI.skin = theSkin;
        GUI.Label(new Rect(Screen.width / 2 - 150, 20, 100, 100), "" + playerScore1);
        GUI.Label(new Rect(Screen.width / 2 + 150, 20, 100, 100), "" + playerScore2);
    }
}
