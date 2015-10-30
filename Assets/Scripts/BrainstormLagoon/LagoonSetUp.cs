using UnityEngine;
using System.Collections;

public class LagoonSetUp : MonoBehaviour {

	public AudioClip[] clips;

	// Use this for initialization
	void Awake () {
		Setup ();
	}

	void Setup ()
	{
		SoundManager.GetInstance().LagoonSetup (clips);
	}

	public void Teardown(bool toMainMap) {
		SoundManager.GetInstance().LagoonTearDown (toMainMap);
	}
}
