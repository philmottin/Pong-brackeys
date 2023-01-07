using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    public Rigidbody2D rb;
    public float ballSpeed = 80f;
    public AudioSource audioSound;

    
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(GoBall());
    }

    // POSSIBLE FIX for ball slowing down after bouncing
    // eventually on some hits the ball slows down completely
    void Update() {
        Vector2 vel = rb.velocity;

        if (vel.x <18 && vel.x > -18 && vel.x !=0) {
            //Debug.Log("VEL before:"+vel.x);
            if (vel.x>0)
                vel.x = 20;
            else 
                vel.x = -20;
            //Debug.Log("VEL after:" + vel.x);
            rb.velocity = vel;
        }
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
            audioSound.pitch = Random.Range(0.8f, 1.2f);
            audioSound.Play();
            Debug.Log("bounceMode: " + MyGameManager.bounceMode);

            Vector2 vel = rb.velocity;

            //increases ball speed on every hit by 1%
            //setting collision detection as continuous on the players rigidbody, solve the ball going through the player once it's fast enough
            if (MyGameManager.ballBounce) {
                vel.x = vel.x*1.01f;
            }

            if (MyGameManager.bounceMode == 1) {
                //ball bances only if bat is moving when it hits           
                //soft
                rb.velocity = new Vector2(vel.x, (-vel.y / 2) + (-collision.collider.attachedRigidbody.velocity.y / 3));
                
            } else if (MyGameManager.bounceMode == 2) {
                //ball bances only if bat is moving when it hits           
                //hard
                rb.velocity = new Vector2(vel.x, (-vel.y / 2) + (-collision.collider.attachedRigidbody.velocity.y * 1.05f));
            } else if (MyGameManager.bounceMode == 3) { 
                //ball bounces depending on where on the bat it hits 
                float bounceScale = 5;
                vel.y = (vel.y + collision.collider.GetComponent<Rigidbody2D>().velocity.y) / 2;
                float posdiff = (rb.position.y - collision.collider.GetComponent<Rigidbody2D>().position.y);
                vel.y = (vel.y + bounceScale * posdiff);
                rb.velocity = new Vector2(vel.x, vel.y);
            }
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
 * Here my script to shot the ball in a random angle with a range of 90° to each side: 

var ballSpeed : float; //arround 300 is good

function GoBall() {
  var leftOrRight = Random.Range(0,2);
  var randomAngle : float;
  if(leftOrRight) {
    //to right side with 90° range
    randomAngle = Random.Range(-45,45) * ((2*Mathf.PI)/360); //degree into radian
  }
  else {
    //to left side with 90° range
    randomAngle = Random.Range(135,225) * ((2*Mathf.PI)/360);
  }
 
  var x : float;
  var y : float;
	
  x = ballSpeed * Mathf.Cos(randomAngle);
  y = ballSpeed * Mathf.Sin(randomAngle);

	
  rigidbody2D.AddForce(new Vector2(x, y));
}
 */

