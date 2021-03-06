﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

/* Controls the workflow of Memory Match Game. Controls the timer, food spawns, the current food to match,
 * and food audio. As well as displaying the game over screen.
 */

public class MemoryMatchGameManager : MonoBehaviour {

	private static MemoryMatchGameManager instance;
	private bool gameStarted;
	private bool gameStartup;
	private int score;
	private GameObject currentFoodToMatch;
	private int difficultyLevel;
	private List<GameObject> activeFoods;
	private GameObject soundManager;

	public Transform foodToMatchSpawnPos;
	public Transform[] foodSpawnPos;
	public Transform[] foodParentPos;
	public float foodScale;
	public float foodToMatchScale;
	public List<GameObject> foods;
	public List<GameObject> dishes;
	public Timer timer;
	public float timeLimit;
	public Text timerText;
	public Text scoreText;
	public Canvas gameOverCanvas;
	public GameObject sceneSoundManager;
	public AudioClip clip;
	public AudioClip win;
	public string language;

	// Use this for initialization
	void Awake () {
		if(instance == null) {
			instance = this;
		}
		else if(instance != this) {
			Destroy(gameObject);
		}

		if(timer != null) {
			timer = Instantiate(timer);
			timer.SetTimeLimit(timeLimit);
		}

		UpdateScoreText();

		activeFoods = new List<GameObject>();
		difficultyLevel = GameManager.GetInstance().GetLevel("MemoryMatch");

		
		soundManager = GameObject.Find ("SoundManager");
		
		language = soundManager.GetComponent<SoundManager>().language;
	}

	// Update is called once per frame
	void Update () {
		if(gameStarted){
			if(score >= difficultyLevel*3 || timer.TimeRemaining () < 0) {
				GameOver();
			}
		}
	}

	void FixedUpdate() {
		timerText.text = "Time: " + timer.TimeRemaining();
	}

	public static MemoryMatchGameManager GetInstance() {
		return instance;
	}

	public void StartGame() {

		gameStartup = true;

		SpawnDishes();

		SelectFoods();

		List<GameObject> copy = new List<GameObject>(activeFoods);

		StartCoroutine(ChooseFoodToMatch());

		for(int i = 0; i < difficultyLevel*3; ++i) {
			GameObject newFood = SpawnFood(copy, true, foodSpawnPos[i], foodParentPos[i], foodScale);
			dishes[i].GetComponent<DishBehavior>().SetFood(newFood.GetComponent<Food>());
		}

		StartCoroutine(RevealDishes());
	}

	void SpawnDishes() {
		for(int i = 0; i < difficultyLevel*3; ++i) {
			dishes[i].SetActive(true);
		}
	}

	IEnumerator RevealDishes() {
		foreach(GameObject d in dishes) {
			d.GetComponent<DishBehavior>().top.GetComponent<SpriteRenderer>().enabled = false;
		}
		yield return new WaitForSeconds(3.0f);
		foreach(GameObject d in dishes) {
			d.GetComponent<DishBehavior>().top.GetComponent<SpriteRenderer>().enabled = true;
		}
		yield return new WaitForSeconds(1.0f);
		gameStartup = false;
		gameStarted = true;
		timer.StartTimer();
	}

	void SelectFoods() {
		int foodCount = 0;
		while(foodCount < difficultyLevel*3){
			int randomIndex = Random.Range(0, foods.Count);
			GameObject newFood = foods[randomIndex];
			if(!activeFoods.Contains(newFood)){
				activeFoods.Add(newFood);
				++foodCount;
			}

		}
	}

	public IEnumerator ChooseFoodToMatch() {
		if(!gameStartup) {
			++score;
			UpdateScoreText();
		}
		
		yield return new WaitForSeconds(1f);

		if(GameObject.Find ("ToMatchSpawnPos").transform.childCount > 0)
			Destroy(currentFoodToMatch);

		if(activeFoods.Count > 0) {
			currentFoodToMatch = SpawnFood(activeFoods, false, foodToMatchSpawnPos, foodToMatchSpawnPos, foodToMatchScale);

			StartCoroutine(PlayFoodName (currentFoodToMatch));
		}
	}

	GameObject SpawnFood(List<GameObject> foodsList, bool setAnchor, Transform spawnPos, Transform parent, float scale) {
		int randomIndex = Random.Range (0, foodsList.Count);
		GameObject newFood = Instantiate(foodsList[randomIndex]);
		newFood.GetComponent<Food>().Spawn(spawnPos, parent, scale);
		if(setAnchor) {
			newFood.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 1f);
			newFood.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 1f);

		}
		foodsList.RemoveAt(randomIndex);
		return newFood;
	}

	public Food GetFoodToMatch() {
		return currentFoodToMatch.GetComponent<Food>();
	}

	void GameOver() {
		PlayClip (win);
		gameStarted = false;
		if(score >= difficultyLevel*3) {
			GameManager.GetInstance().LevelUp("MemoryMatch");
		}

		timer.StopTimer();
		timerText.gameObject.SetActive(false);
		scoreText.gameObject.SetActive(false);
		gameOverCanvas.gameObject.SetActive(true);
		Text gameOverText = gameOverCanvas.GetComponentInChildren<Text>();
		gameOverText.text = "Great job! You matched " + score + " healthy foods!";
	}

	public bool isGameStarted() {
		return gameStarted;
	}

	void UpdateScoreText() {
		scoreText.text = "Score: " + score;
	}

	void PlayClip(AudioClip clip)
	{
		sceneSoundManager.GetComponent<SceneSound> ().PlayClip (clip);
	}

	IEnumerator PlayFoodName(GameObject currentFoodToMatch)
	{
		if (language == "English") {

			yield return new WaitForSeconds(0.5f);

			clip = currentFoodToMatch.GetComponent<MemoryMatchFood> ().clips [0];
			PlayClip (clip);

		} 

		else 
		{
			yield return new WaitForSeconds(0.5f);

			clip = currentFoodToMatch.GetComponent<MemoryMatchFood> ().clips [1];
			PlayClip (clip);
		}
	}

}
