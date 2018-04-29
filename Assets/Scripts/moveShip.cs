using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveShip : MonoBehaviour {

	private Animator animator;

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

		//ship animator
		animator = GetComponent<Animator> ();
	}
	

	// Update is called once per frame
	void Update () {

		//ship speed
		float speed = 5f;
		Vector2 newVelocity = new Vector2(0f,0f);

		// Game controls if we are on android or ios
		if(Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer){

			// if no touch on screen then the ship slowly goes back
			newVelocity.x = -0.5f;
			
			//foreach screen touch
			for(int i =0; i< Input.touchCount ; i++){

				Touch myTouch = Input.GetTouch(i);
				Vector3 touchPos= Camera.main.ScreenToWorldPoint(new Vector3(myTouch.position.x,myTouch.position.y,0f));

				//touch located in the left part of the screen
				if(touchPos.x < leftTopCameraBorder.x + (rightTopCameraBorder.x-leftTopCameraBorder.x)/6){
					// very slowly moving right
					newVelocity.x = 0.03f;

					// offset used
					float offset = 0.8f;
					if(touchPos.y > transform.position.y + offset )
						newVelocity.y=0.8f;
					else if (touchPos.y < transform.position.y - offset)
						newVelocity.y=-0.8f;
					
				}
				// SHOT : touch located in the up right part of the screen
				else if(touchPos.x > rightTopCameraBorder.x - (rightTopCameraBorder.x-leftTopCameraBorder.x)/6
					&&
					touchPos.y > rightTopCameraBorder.y -(rightTopCameraBorder.y-rightBottomCameraBorder.y)/2){
					
					gameObject.GetComponent<shootAgain>().shoot();
				}
				// BOOST : touch located in the down right part of the screen
				else if(touchPos.x > rightTopCameraBorder.x - (rightTopCameraBorder.x-leftTopCameraBorder.x)/6
						&&
					touchPos.y < rightTopCameraBorder.y -(rightTopCameraBorder.y-rightBottomCameraBorder.y)/2){
					
					newVelocity.x=0.9f;
				}
			}
			//adding to the ship roration
			gameObject.GetComponent<Rigidbody2D>().rotation+=newVelocity.y;
			//multiplying the new velocity vector by ship speed
			newVelocity *= speed ;
		}else {
			
			// getting speed according to keyboard input
			float speedH = speed * Input.GetAxis ("Horizontal");
			float speedV = speed * Input.GetAxis ("Vertical");

			newVelocity=new Vector2 (speedH,speedV);
			//adding to the ship roration
			gameObject.GetComponent<Rigidbody2D>().rotation+=Input.GetAxis ("Vertical");
		}

		gameObject.GetComponent<Rigidbody2D>().velocity = newVelocity;
		gameObject.GetComponent<Rigidbody2D>().rotation*=0.96f;
		

		// s is a value send to the animator
		float s;

		// s < 0 means animation for slow speed
		if(newVelocity.x < 0) s = -1f;
		// 1 < s means animation for high speed
		else if (1 < newVelocity.x)	s = 1f;
		// 0 < s < 1 means animation for medium speed
		else s = 0f;

		animator.SetFloat("speed",s);	
	}

}
