using UnityEngine;
using System.Collections;

public class SwitchScene: MonoBehaviour {

	public string sceneToLoad;

	public void loadScene() {
		Application.LoadLevel(sceneToLoad);
	}
}
