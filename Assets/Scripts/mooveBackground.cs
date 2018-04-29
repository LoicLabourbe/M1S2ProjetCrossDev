using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mooveBackground : MonoBehaviour {

	// Background restart position
	float positionRestartX = 36.21434f;

	// Background moving speed
	float speed=-0.4f;

	Vector3 leftBottomCameraBorder;

	// Use this for initialization
	void Start () {
		leftBottomCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3(0,0,0));
		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (speed,0f);
	}
	
	// Update is called once per frame
	void Update () {

		float boudSizeX = gameObject.GetComponent<SpriteRenderer> ().bounds.size.x;

		//if the background is out of the screen, replace it at restart position
		if (transform.position.x < leftBottomCameraBorder.x - (boudSizeX/2)) 
			transform.position = new Vector3(positionRestartX,transform.position.y,transform.position.z);

	}
}
