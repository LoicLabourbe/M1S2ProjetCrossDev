using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class detectIfZeroLife : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		if(SceneManager.GetActiveScene().name=="mainScene"){
			// if the game object representing the last life is missing 
			if(GameObject.FindGameObjectWithTag("life1")==null)
				SceneManager.LoadScene("GameOver");
		}
	}

}
