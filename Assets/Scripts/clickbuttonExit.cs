using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class clickbuttonExit : MonoBehaviour {

	// Exit the application
	public void onClick(){
		SoundState.Instance.touchButtonSound();
		Application.Quit();
	}

}
