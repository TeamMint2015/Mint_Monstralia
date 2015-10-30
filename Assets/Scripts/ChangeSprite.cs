using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangeSprite : MonoBehaviour {

	Sprite oldSprite;
	bool changed = false;

	void Awake() {
		oldSprite = gameObject.GetComponent<Image>().sprite;
	}

	public void changeSpriteImage(Sprite newSprite) {
		Sprite changeTo;

		if(changed) {
			changeTo = oldSprite;
			changed = false;
		}
		else {
			changeTo = newSprite;
			changed = true;
		}

		gameObject.GetComponent<Image>().sprite = changeTo; 
	}
}
