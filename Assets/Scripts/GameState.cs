using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour {

	public static GameState Instance;
	private int scorePlayer=0;
	private int bestScoreEver=0;

	// Use this for initialization
	void Start () {
		if(Instance==null){
			Instance=this;
			DontDestroyOnLoad(Instance.gameObject);
		}else if(this!=Instance){
			Destroy(this.gameObject);
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		if(SceneManager.GetActiveScene().name=="mainScene"){
			GameObject.FindWithTag("scoreLabel").GetComponent<Text>().text=""+scorePlayer;
		}	
	}

	public void addScorePlayer(int points){
		scorePlayer+=points;
	}

	public void resetScore(){
		scorePlayer=0;
	}

	// Update the best score if the current score is superior
	public void updateIfBestScore(){
		if(scorePlayer>bestScoreEver)
			bestScoreEver=scorePlayer;
	}

	public int getScorePlayer(){
		return scorePlayer;
	}

	public int getBestScore(){
		return bestScoreEver;
	}

}
