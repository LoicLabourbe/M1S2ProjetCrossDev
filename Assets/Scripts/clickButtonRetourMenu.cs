using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class clickButtonRetourMenu : MonoBehaviour {

	//back to the game menu
	public void onClick(){
		SoundState.Instance.touchButtonSound();
		GameState.Instance.resetScore();
		SceneManager.LoadScene("Menu");
	}
}
