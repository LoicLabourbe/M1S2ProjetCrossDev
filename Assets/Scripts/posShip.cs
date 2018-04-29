using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class posShip : MonoBehaviour {
	
	Vector3 leftBottomCameraBorder;
	Vector3 rightBottomCameraBorder;
	Vector3 leftTopCameraBorder;
	Vector3 rightTopCameraBorder;
	Vector3 siz;

	// Use this for initialization
	void Start () {
		leftBottomCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3(0,0,0));
		rightBottomCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3(1,0,0));
		leftTopCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3(0,1,0));
		rightTopCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3(1,1,0));
	}

	void Update () {

		siz.x = gameObject.GetComponent<SpriteRenderer> ().bounds.size.x;
		siz.y = gameObject.GetComponent<SpriteRenderer> ().bounds.size.y;

		//down
		if (transform.position.y < leftBottomCameraBorder.y + (siz.y/2)) 
			gameObject.transform.position = new Vector3(transform.position.x,leftBottomCameraBorder.y+(siz.y/2),transform.position.z);
		

		//up
		if (transform.position.y > leftTopCameraBorder.y - (siz.y/2))
			gameObject.transform.position = new Vector3(transform.position.x,leftTopCameraBorder.y-(siz.y/2),transform.position.z);


		// If we are on smartphone the ship can't go to the most left and most right part of the screen because it is reserved for tactile screen inputs.
		//Smartphone
		if(Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer){

			// The screen is divided in 6 parts, the ship can't go into the most left part
			if (transform.position.x -(siz.x/2) < leftTopCameraBorder.x + (rightTopCameraBorder.x-leftTopCameraBorder.x)/6 )
				gameObject.transform.position = new Vector3(leftTopCameraBorder.x + (rightTopCameraBorder.x-leftTopCameraBorder.x)/6+ (siz.x/2),transform.position.y,transform.position.z);

			// The screen is divided in 6 parts, the ship can't go into the most right part
			if (transform.position.x + (siz.x/2) > rightTopCameraBorder.x - (rightTopCameraBorder.x-leftTopCameraBorder.x)/6)
				gameObject.transform.position = new Vector3(rightTopCameraBorder.x - (rightTopCameraBorder.x-leftTopCameraBorder.x)/6 - (siz.x/2),transform.position.y,transform.position.z);
		// Other	
		}else{

			//left
			if (transform.position.x -(siz.x/2) < leftTopCameraBorder.x )
				gameObject.transform.position = new Vector3(leftTopCameraBorder.x + (siz.x/2),transform.position.y,transform.position.z);

			//right
			if (transform.position.x + (siz.x/2) > rightTopCameraBorder.x)
				gameObject.transform.position = new Vector3(rightTopCameraBorder.x - (siz.x/2),transform.position.y,transform.position.z);
		}
	}
}
