using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Life handler for asteroids, right now they have 1 health
public class lifeHandler : MonoBehaviour {

	private int nbLifeLeft;
	
	void Start () {
		nbLifeLeft=1;
	}
	
	public void decreaseLife(int i){
		if (nbLifeLeft > 0)
			nbLifeLeft=(nbLifeLeft-i>0)?nbLifeLeft-i:0;
	}

	public bool isDead(){
		return nbLifeLeft==0;
	}
}
