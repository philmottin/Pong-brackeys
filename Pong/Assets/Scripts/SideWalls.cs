using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWalls : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.name == "Ball") {
            string wallName = transform.name;
            MyGameManager.Score(wallName);
            collision.gameObject.SendMessage("ResetBall");
        }
    }
}
