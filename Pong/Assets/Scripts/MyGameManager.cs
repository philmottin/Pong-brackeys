using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGameManager : MonoBehaviour
{
    public static int playerScore1 = 0;
    public static int playerScore2 = 0;

    public GUISkin theSkin;

    public BallControl ball;

    public static void Score(string wallName) {
        if (wallName == "rightWall") {
            playerScore1++;
        } else {
            playerScore2++;
        }
    }
    private void OnGUI() {
        GUI.skin = theSkin;

        // (Screen.width / 2) - (150-20)
        // anchor point on Fonts are top-left so we subtract half of the font width to center it cerrectly
        // 100 is not the actual font width, is the width of the element which the font is contained.
        // 150 is the offset to the desire location
        // +-20 is the eyeballing result for centering.
        GUI.Label(new Rect((Screen.width / 2) - (150+20), 20, 100, 100), "" + playerScore1);
        GUI.Label(new Rect((Screen.width / 2) + (150-20), 20, 100, 100), "" + playerScore2);

        // (Screen.width/2)-(121/2)
        // anchor point on Screen.width is top-left so we subtract half of the button width to center it cerrectly
        if (GUI.Button(new Rect((Screen.width/2)-(121/2), 35, 121, 53), "RESET")) {
            playerScore1 = 0;
            playerScore2 = 0;
            //ball.gameObject.SendMessage("ResetBall");
            ball.ResetBall();
        }
    }
}
