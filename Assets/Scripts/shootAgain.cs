using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootAgain : MonoBehaviour {

	Vector3 siz;

	// minimal time between two shot 
	float timeBetweenFire=0.25f;
	// time of the last ship fire
	float lastFire;

	// Use this for initialization
	void Start () {
		lastFire = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		
		//	Get	the	size	of	the	gameObject	containing	this	script	
		siz.x =	gameObject.GetComponent<SpriteRenderer>().bounds.size.x;	
		siz.y =	gameObject.GetComponent<SpriteRenderer>().bounds.size.y;	
	
		//	If	space key is pressed	
		if(Input.GetKeyDown(KeyCode.Space))
			shoot();
	}

	public void shoot(){
		// if enough time has passed since last shot
		if(Time.time > lastFire + timeBetweenFire){
			lastFire=Time.time;
			//	Get	the	position	of	the	shoot	using	the	ship position	
			Vector3	tmpPos = new Vector3(transform.position.x+siz.x/2,transform.position.y,transform.position.z);	
			//	Instantiate	shootOrange	
			GameObject gY = Instantiate(Resources.Load("shootOrange"),tmpPos,Quaternion.identity) as GameObject;		
			SoundState.Instance.shipShootSound();
		}
	}
}
