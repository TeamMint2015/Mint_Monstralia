using UnityEngine;
using System.Collections;

public class ColorDetector : Colorable {
	public Transform[] destinations;
	private int nextDest = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AddFood(GameObject food) {
		food.transform.position = destinations[nextDest++].position;
	}
}
