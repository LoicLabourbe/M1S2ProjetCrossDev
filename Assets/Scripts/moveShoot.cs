using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveShoot : MonoBehaviour {

	float speed = 11f;
	Vector3 rightBottomCameraBorder;
	Vector3 rightTopCameraBorder;
	Vector3 siz;

	float rorationShip;

	// Use this for initialization
	void Start () {
		rightBottomCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3(1,0,0));
		rightTopCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3(1,1,0));

		// Get the ship rotation to influence the vertical speed of the shot
		float rorationShip = 0.2f*GameObject.FindGameObjectWithTag("myship").GetComponent<Rigidbody2D>().rotation;
		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (speed,rorationShip);
	}
	
	// Update is called once per frame
	void Update () {
		
		siz.x = gameObject.GetComponent<SpriteRenderer> ().bounds.size.x;
		siz.y = gameObject.GetComponent<SpriteRenderer> ().bounds.size.y;

		//down
		if (transform.position.y < rightBottomCameraBorder.y + (siz.y/2)) 
			gameObject.transform.position = new Vector3(transform.position.x,rightBottomCameraBorder.y+(siz.y/2),transform.position.z);

		//up
		if (transform.position.y > rightTopCameraBorder.y - (siz.y/2)) 
			gameObject.transform.position = new Vector3(transform.position.x,rightTopCameraBorder.y-(siz.y/2),transform.position.z);

		//right
		if (transform.position.x  > rightTopCameraBorder.x - (siz.x/2)) 
    		Destroy(gameObject);
	}


	void OnTriggerEnter2D(Collider2D collider) {

		if(collider.tag=="asteroid"){
			collider.gameObject.GetComponent<lifeHandler>().decreaseLife(1);
			// if asteroid life has reached 0
			if(collider.gameObject.GetComponent<lifeHandler>().isDead()){
				// test because we want to add fadeOut script only once
				if(collider.gameObject.GetComponent<fadeOut>()==null){
					SoundState.Instance.asteroidExplosionSound();
					//destroy the boxCollider of the asteroid to avoid collision with player
					Destroy(collider.gameObject.GetComponent<BoxCollider2D>());
					GameState.Instance.addScorePlayer(1);
					collider.gameObject.AddComponent<fadeOut>();
					// decrease asteroid speed 
					collider.gameObject.GetComponent<moveAsteroid>().decreaseSpeed();
					//destroy the shot
					Destroy(gameObject);
				}
			}
		}
    }

}
