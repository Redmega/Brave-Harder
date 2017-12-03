using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MelMovement : MonoBehaviour {

    public float moveSpeed = 1;
    private float movement = 0;
    private Rigidbody2D rigidBody;
    public float maxSpeed = 20;
	public Text finalScore;


	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        movement = Input.GetAxis("Horizontal");
        //Right movement
        if (Input.GetKey(KeyCode.RightArrow) && movement < maxSpeed)
        {
            rigidBody.AddForce(moveSpeed * movement * Vector2.right, ForceMode2D.Impulse);
        }

        //Left movement
        if (Input.GetKey(KeyCode.LeftArrow) && movement < maxSpeed)
        {
            rigidBody.AddForce(moveSpeed * -movement * Vector2.left, ForceMode2D.Impulse);
        }
        
        
	}

	void OnBecameInvisible() {
		Death ();
	}

    void OnCollisionEnter2D(Collision2D col)
    {
		if (col.gameObject.name == "EnemyJackson(Clone)") {
			Death ();
		}
    }

	void Death()
	{
		AudioSource endgame = GetComponent<AudioSource> ();
		GetComponent<Renderer> ().enabled = false;
		GameState.EndGame ();
		endgame.Play ();
		finalScore.text = "Game Over! Your score is " + GameState.userScore;
		Invoke ("Kill", 6);
	}

	void Kill() {
		Application.Quit ();
	}
}
