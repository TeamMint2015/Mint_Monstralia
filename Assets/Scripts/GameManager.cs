using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	private Dictionary<string, int> gameLevels;
	private Dictionary<string, int> gameStars;

	public static GameManager instance = null;

	string monster;

	void Awake() {
		if(instance == null) {
			instance = this;
		}
		else if(instance != this) {
			Destroy(gameObject);
		}
		DontDestroyOnLoad(this);
	}

	public static GameManager GetInstance() {
		return instance;
	}

	void Start() {
		gameLevels = new Dictionary<string, int>();
		gameLevels.Add("Brainbow", 1);
		gameLevels.Add("MemoryMatch", 1);

		gameStars = new Dictionary<string, int>();
		gameStars.Add ("Brainbow", 0);
		gameStars.Add("MemoryMatch", 0);
	}

	public void setMonster(string color) {
		this.monster = color;
	}
	
	public string getMonster() {
		return monster;
	}

	public int GetLevel(string gameName) {
		return gameLevels[gameName];
	}

	public bool LevelUp(string gameName) {
		print("leveling up");
		if(gameStars[gameName] <= 3) {
			gameStars[gameName] += 1;
			if(gameLevels[gameName] != 3){
				gameLevels[gameName] += 1;
			}
			return true;
		}
		return false;
	}

	public int GetNumStars(string gameName) {
		return gameStars[gameName];
	}

}
