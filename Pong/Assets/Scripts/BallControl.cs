using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    public Rigidbody2D rb;
    public float ballSpeed = 100f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GoBall());
    }

    public IEnumerator GoBall() {
        yield return new WaitForSeconds(2f);
        float randomNumber = Random.Range(0f, 1f);
        if (randomNumber <= 0.5f) {
            rb.AddForce(new Vector2(ballSpeed, 10f));
        } else {
            rb.AddForce(new Vector2(-ballSpeed, -10f));
        }
    }

    public void ResetBall() {
        transform.position = new Vector2(0f, 0f);
        rb.velocity = new Vector2(0f, 0f);
        StartCoroutine(GoBall());
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.tag == "Player") {
            float velY = rb.velocity.y;
            float velX = rb.velocity.x;
            //float velX = 15f;
            rb.velocity = new Vector2(velX, (velY / 2) + (collision.collider.attachedRigidbody.velocity.y / 3));
        }
    }    
}


/*
 * For anyone having the issue were the ball slows down on x-axis put this in the second function if (colInfo.collider.tag == "Player"){
		rigidbody2D.velocity.x = 15;
	}
	if (colInfo.collider.tag == "Player2"){
		rigidbody2D.velocity.x = -15;

also for second player create a tag called Player2! Hope this helped
 * */

/*
 * If you wanted the ball to also bounce depending on where on the bat it hits (i.e. if it hits near the top of the bat, it gets a slight upwards force), try this code instead (define bounceScale just above the start function using public float bounceScale = 7;):
 float velY = GetComponent<Rigidbody2D> ().velocity.y;

            velY = (velY + colInfo.collider.GetComponent<Rigidbody2D> ().velocity.y)/2;

            float posdiff = (GetComponent<Rigidbody2D> ().position.y-colInfo.collider.GetComponent<Rigidbody2D>().position.y);

            velY = (velY + bounceScale * posdiff);

            GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, velY);
*/

/*
 * 
 * I find it more funny to be like this:

rigidbody2D.velocity.y = rigidbody2D.velocity.y/2 + colInfo.collider.rigidbody2D.velocity.y*1.15;

the ball bounces faster and slower depending on impact angle and player movement.
 * */