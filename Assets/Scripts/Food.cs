using UnityEngine;
using System.Collections;

/// <summary>
/// Food.
/// </summary>
public abstract class Food : Colorable {

	public virtual void Spawn(Transform spawnPos, Transform parent = null, float scale = 1.0f) {
		if(parent != null) {
			gameObject.transform.SetParent (parent.transform);
		}
		gameObject.transform.localPosition = spawnPos.localPosition;
		gameObject.transform.localScale = new Vector3(scale, scale, 1);
		gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
	}
}
