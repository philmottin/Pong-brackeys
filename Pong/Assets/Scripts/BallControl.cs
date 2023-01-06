using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        float randomNumber = Random.Range(0f, 1f);
        if (randomNumber <= 0.5) {
            rb.AddForce(new Vector2(80,10));
        } else {
            rb.AddForce(new Vector2(-80, -10));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.tag == "Player") {
            float velY = rb.velocity.y;
            float velX = rb.velocity.x;
            rb.velocity = new Vector2(velX, (velY / 2) + (collision.collider.attachedRigidbody.velocity.y / 3));
        }
    }    
}
