using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour {
	
	private int energyLevel;
	//private string emotion;
	private string color;
	//private string bodyPart;
	//private int xPos;
	//private int yPos;
	
	void Awake() {
		SpriteLibrary.LoadSprite(color);
	}

	//getters... remove if possible
	public string getColor() { return this.color; }
	//public string getEmotion() { return this.emotion; }
	//public string getBodyPart() { return this.bodyPart; }
	public int getEnergyLevel() { return this.energyLevel; }
	//public int getXPos() { return this.xPos; }
	//public int getYPos() { return this.yPos; }

	//setters... remove if possible
	public void setColor(string color) { this.color = color; }
	public void setEnergyLevel(int energyLevel) { this.energyLevel = energyLevel; }
	//public void setEmotion(string emotion) { this.emotion = emotion; }
	//public void setXPos(int newX) { this.xPos = newX; }
	//public void setYPos(int newY) { this.yPos = newY; }

}
