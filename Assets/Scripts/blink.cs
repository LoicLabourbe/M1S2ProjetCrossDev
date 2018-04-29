using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blink : MonoBehaviour {

	// blinking duration
	float duration=1f;

	// time between frame blink
	float blinkingRate=0.08f;

	float lastBlinkTime;
	float startingTime;

	// Use this for initialization
	void Start () {
		startingTime = Time.time;
		lastBlinkTime =  Time.time;
		GetComponent<SpriteRenderer>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		//if blinking duration is over
		if(Time.time > startingTime + duration){
			GetComponent<SpriteRenderer>().enabled = true;
			Destroy(GetComponent<blink>());
		// if it's time to blink
		}else if(Time.time > lastBlinkTime+blinkingRate){
			lastBlinkTime=Time.time;
			GetComponent<SpriteRenderer>().enabled = !GetComponent<SpriteRenderer>().enabled;
		}
	}
}
