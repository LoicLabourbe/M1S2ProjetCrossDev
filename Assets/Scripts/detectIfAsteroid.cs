using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectIfAsteroid : MonoBehaviour {

	Vector3 siz;
	Vector3 rightBottomCameraBorder;
	Vector3 rightTopCameraBorder;
	GameObject [] respawns;

	// Use this for initialization
	void Start () {
		rightBottomCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3(1,0,0));
		rightTopCameraBorder = Camera.main.ViewportToWorldPoint(new Vector3(1,1,0));
	}
	
	// Update is called once per frame
	void Update () {
		//Create a tab containinng all the asteroid in a scene
		respawns=GameObject.FindGameObjectsWithTag("asteroid");

		// if more than 0 asteroid
		if(respawns.Length>0){
			siz.x=respawns[0].GetComponent<SpriteRenderer>().bounds.size.x;
			siz.y=respawns[0].GetComponent<SpriteRenderer>().bounds.size.y;


			//if less than 15asteroid
			if(respawns.Length<15){
				//choose randomly if an asteroid will be created or not
				if(Random.Range(1,100)<=10||respawns.Length<15){

					float posX=rightBottomCameraBorder.x+siz.x;
					float posY;

					bool intersect;

					// loop to get a random Y coordinate that does not intersect with other asteroids
					do{
						intersect = false;
						posY = Random.Range(rightBottomCameraBorder.y-siz.y,(rightTopCameraBorder.y+siz.y));

						float asteroidX, asteroidY, asteroidBoundX, asteroidBoundY;

						//check if this new asteroid wont intersect with another asteroid
						foreach(GameObject go in respawns){

							asteroidX=go.GetComponent<SpriteRenderer>().transform.position.x;
							asteroidBoundX=go.GetComponent<SpriteRenderer>().bounds.size.x;

							//if the asteroid is not in the screen yet : test further
							if(asteroidX+(asteroidBoundX/2)>rightBottomCameraBorder.x){
								
								asteroidY=go.GetComponent<SpriteRenderer>().transform.position.y;
								asteroidBoundY=go.GetComponent<SpriteRenderer>().bounds.size.y;

								// we consider it intersects : start over the loop
								if(asteroidY-(asteroidBoundY/2)<posY && asteroidY+(asteroidBoundY/2)>posY){
									intersect=true;
									break;
								}
							}
						}
					//while there is an intersection : find another position
					}while(intersect);

					//create a new asteroid
					Vector3 asteroidPos=new Vector3(posX,posY,transform.position.z);

					//instanciation
					GameObject gY=Instantiate(Resources.Load("asteroidSP"),asteroidPos,Quaternion.identity)as GameObject;

				}
			}
		}
	}
	
}
