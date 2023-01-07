using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2AI : MonoBehaviour
{

    public Rigidbody2D player2;
    public Transform ball;

    float speed = 10; 
    float babyMode = 0.2f;
    float easy = 0.3f;
    float medium = 0.5f;
    float hard = 0.6f;
    float impossible = 0.8f; 

    // Update is called once per frame
    void Update()
    {
        float difficulty = babyMode;

        if (MyGameManager.difficulty == "easy") {
            difficulty = easy;
        } else if (MyGameManager.difficulty == "medium") {
            difficulty = medium;
        } else if (MyGameManager.difficulty == "hard") {
            difficulty = impossible;        
        } else { // auto
            int diffCalc = MyGameManager.playerScore1 - MyGameManager.playerScore2;
            switch (diffCalc) {
                case < 0:
                    difficulty = babyMode;
                    break;
                case <= 3:
                    difficulty = easy;
                    break;
                case <= 5:
                    difficulty = medium;
                    break;
                case <= 8:
                    difficulty = hard;
                    break;
                case > 8:
                    difficulty = impossible;
                    break;

            }
        }
        //Debug.Log("difficulty: " + difficulty);
        Vector2 vel = player2.velocity;
        vel.y = (ball.transform.position.y - player2.transform.position.y) * speed * difficulty;
        player2.velocity = vel;
    }
}
