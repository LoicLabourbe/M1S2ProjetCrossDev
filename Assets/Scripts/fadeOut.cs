using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeOut : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		
		Color color = GetComponent<SpriteRenderer>().color;
		
		//decrease transparency
		color.a-=0.04f;

		GetComponent<SpriteRenderer>().color=color;

		//if transparent destroy the game object
		if(color.a<0)
			Destroy(gameObject);
	}
}
