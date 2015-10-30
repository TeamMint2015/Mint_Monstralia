using UnityEngine;
using System;
public class Colorable : MonoBehaviour {

	[Serializable]
	public enum Color {
		Red,
		Yellow,
		Green,
		Purple
	};

	public Color color;
}
