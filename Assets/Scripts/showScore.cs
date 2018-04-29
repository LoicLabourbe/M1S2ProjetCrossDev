using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class showScore : MonoBehaviour {

	// Use this for initialization
	void Start () {		
		//Update if the player had made a better score
		GameState.Instance.updateIfBestScore();

		int bestScore=GameState.Instance.getBestScore();		
		int score=GameState.Instance.getScorePlayer();

		// reset score for next session
		GameState.Instance.resetScore();

		// Show the score and the best score on the game over screen
		GameObject.FindGameObjectWithTag("bestScore").GetComponent<Text>().text+=""+bestScore;
		GameObject.FindGameObjectWithTag("finalScore").GetComponent<Text>().text+=""+score;
	}

}
