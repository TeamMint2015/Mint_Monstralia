using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour {
	
	public GameObject singleton;

	void Awake() { 

		if(GameManager.instance == null) {
			Instantiate(singleton);
		}

	}
}
