using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundState : MonoBehaviour {

	public static SoundState Instance;

	//sound when boutton clicking
	public AudioClip touchButton;
	// ship shooting 
	public AudioClip playerShotSound;
	// asteroid explosion
	public AudioClip bangSmall;
	//Main level soundtrack
	public AudioClip DefenseLine;
	//Game over soundtrack
	public AudioClip StarCommander1;

	private AudioSource audioSource;


	// Use this for initialization
	void Start () {
		if(Instance == null){
			Instance = this;
			SceneManager.sceneLoaded += OnLevelLoaded;
			audioSource = gameObject.GetComponent<AudioSource>();
			DontDestroyOnLoad(Instance.gameObject);
		}else if(this != Instance){
			Destroy(this.gameObject);
		}
	}
	
	

	void OnLevelLoaded (Scene scene, LoadSceneMode mode){
		if(scene.name == "Menu"){
			audioSource.clip = DefenseLine;
			audioSource.Play();
		}
		if(scene.name == "GameOver"){
			audioSource.clip = StarCommander1;
			audioSource.Play();
		}
	}

	// Menu button clicking sound
	public void touchButtonSound(){
		MakeSound(touchButton);
	}

	public void shipShootSound(){
		MakeSound(playerShotSound);
	}

	public void asteroidExplosionSound(){
		audioSource.PlayOneShot(bangSmall,0.9f);
	}

	private void MakeSound(AudioClip originalClip){
		AudioSource.PlayClipAtPoint(originalClip,transform.position);
	}



}
