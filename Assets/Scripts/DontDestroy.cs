using UnityEngine;
using System.Collections;

public class DontDestroy : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		print("Setting " + gameObject.name + " destoyed on load to false");
		DontDestroyOnLoad(gameObject);
	}
}
