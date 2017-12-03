using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameState : MonoBehaviour
{

	public static int difficulty;
	public static bool gameOver = false;
	public static int userScore = 0;
	public Text CurrentScore;
	// Use this for initialization

	public static void EndGame() {
		gameOver = true;
	}

	void Start ()
	{
		difficulty = 0;
		InvokeRepeating ("IncreaseDifficulty", 0, 5);
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void IncreaseDifficulty() {
		difficulty++;
		if (!gameOver) {
			userScore += 5;
			CurrentScore.text = userScore.ToString ();
		}
	}
}

