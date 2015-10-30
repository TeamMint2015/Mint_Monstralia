using UnityEngine;
using System.Collections;

public class SpriteLibrary : ScriptableObject {

	// Use this for initialization
	public static void LoadSprite (string name) {
		Debug.Log(name);
		Sprite monsterSprite = Resources.Load<Sprite>(name);
		//GameObject.GetComponent<SpriteRenderer>().sprite = monsterSprite;
	}
}
