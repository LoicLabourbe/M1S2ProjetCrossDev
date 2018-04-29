using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveAsteroid : MonoBehaviour {
	
	//the usual camera
	Vector3 leftBottomCameraBorder;
	Vector3 rightBottomCameraBorder;
	Vector3 leftTopCameraBorder;
	Vector3 rightTopCameraBorder;

	// size of the asteroid
	Vector3 siz;

	//speed divisor default value is 1, right now speed doesn't decrease
	float speedDivisor=1f;
	
	float speedH;
	float speedV;
	float rotation;

	// Use this for initialization
	void Start () {
		leftBottomCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3(0,0,0));
		rightBottomCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3(1,0,0));
		leftTopCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3(0,1,0));
		rightTopCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3(1,1,0));

		//random horizontal and vertical speed and rotation for the asteroid
		speedH = Random.Range(-4f,-7f);
		speedV=Random.Range(-1.5f,1.5f);
		rotation=Random.Range(-2f,2f);

	}
	
	// Update is called once per frame
	void Update () {

		siz.x = gameObject.GetComponent<SpriteRenderer> ().bounds.size.x;
		siz.y = gameObject.GetComponent<SpriteRenderer> ().bounds.size.y;

		// speed divisor is used to represent shot impact
		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (speedH/speedDivisor,speedV);
		gameObject.GetComponent<Rigidbody2D>().rotation+=rotation;


		//down
		if (transform.position.y + (siz.y/2) < leftBottomCameraBorder.y) 
			Destroy(gameObject);

		//up
		if (transform.position.y - (siz.y/2) > leftTopCameraBorder.y)
			Destroy(gameObject);

		//left
		if (transform.position.x  < leftTopCameraBorder.x - (siz.x/2))
   		 	Destroy(gameObject);

	}


	void OnTriggerEnter2D(Collider2D collider) {

		// if two asteroid collide
		if(collider.tag=="asteroid"){
			//if they are not moving in the same direction
         	if(collider.gameObject.GetComponent<moveAsteroid>().speedV*speedV <0)
         		//simulate an impact
				speedV*=-0.8f;
		}
		
		// if the asteroid collides with the player's ship
		if(collider.tag=="myship"){
			// if the ship is not blinking (equivalent to invulnerability)
			if(collider.gameObject.GetComponent<blink>()==null){
				//adding the blink component
				collider.gameObject.AddComponent<blink>();
				//Looking for a life to remove
				if(GameObject.FindGameObjectWithTag("life3"))	
					GameObject.FindGameObjectWithTag("life3").AddComponent<fadeOut>();
				else if(GameObject.FindGameObjectWithTag("life2"))	
					GameObject.FindGameObjectWithTag("life2").AddComponent<fadeOut>();
				else if(GameObject.FindGameObjectWithTag("life1"))	
					GameObject.FindGameObjectWithTag("life1").AddComponent<fadeOut>();
			}
		}
    }

    // change the speed divisor to simulate impact
    public void decreaseSpeed(){
    	speedDivisor=1.8f;
    }

}
