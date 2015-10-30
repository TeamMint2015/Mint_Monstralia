using UnityEngine;
using System.Collections;

public class DishBehavior : MonoBehaviour {

	///The food belonging to this dish.
	private Food myFood;
	///Has the player made a guess.
	private static bool isGuessing;

	///Reference to the top part of the dish.
	public GameObject top;
	///Reference to the bottom part of the dish.
	public GameObject bottom;

	///Use this for initialization.
	void Start () {
		isGuessing = false;
	}

	/**
	 * Set the food of this dish.
	 * @param food, a Food
	 */
	public void SetFood(Food food) {
		myFood = gameObject.GetComponentsInChildren<Food>()[0];
	}

	/**
	 * OnMouseDown is called when the player clicks (or taps) one of the dishes.
	 * @return WaitForSeconds for a delay.
	 */
	IEnumerator OnMouseDown() {
		if(!isGuessing && MemoryMatchGameManager.GetInstance().isGameStarted()) {
			isGuessing = true;
			//Reveal the food underneath the dish by setting the sprite renderer to disabled.
			top.GetComponent<SpriteRenderer>().enabled = false;
			if(MemoryMatchGameManager.GetInstance().GetFoodToMatch().name != myFood.name) {
				yield return new WaitForSeconds(1.5f);
				top.GetComponent<SpriteRenderer>().enabled = true;
			}
			else {
				top.GetComponent<SpriteRenderer>().enabled = false;
				MemoryMatchGameManager.GetInstance().ChooseFoodToMatch();
			}
			//The player can now guess again.
			isGuessing = false;
			return true;
		}
	}
}
