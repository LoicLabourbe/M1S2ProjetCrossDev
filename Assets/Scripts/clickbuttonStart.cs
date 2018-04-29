using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class clickbuttonStart : MonoBehaviour {

	// load the game level
	public void onClick(){
		SoundState.Instance.touchButtonSound();
		SceneManager.LoadScene("mainScene");
	}

}
