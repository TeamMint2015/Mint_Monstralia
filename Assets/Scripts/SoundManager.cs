using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	private static SoundManager instance = null;
	private bool muted = false;
	public AudioClip gameBackgroundMusic;
	public AudioSource backgroundSource;
	public AudioSource SFXsource;

	void Awake () {
		if(instance == null) {
			instance = this;
		}
		else if(instance != this) {
			Destroy(gameObject);
		}
		DontDestroyOnLoad(this);
	}

	public static SoundManager GetInstance() {
		return instance;
	}

	public void mute() {
		if(!muted) {
			AudioListener.pause = true;
			muted = true;
		}
		else {
			AudioListener.pause = false;
			muted = false;
		}
	}

	public void PlayClip(AudioClip clip) {
		SFXsource.clip = clip;
		SFXsource.Play ();
	}

	public void ChangeBackgroundMusic(AudioClip newBackgroundMusic) {
		backgroundSource.clip = newBackgroundMusic;
		backgroundSource.Play ();
	}

	public void LagoonSetup (AudioClip[] clips) {

		if(!muted) {
			backgroundSource.Stop ();
		}
		foreach(AudioClip clip in clips) {
			AudioSource newSource = gameObject.AddComponent<AudioSource>();
			newSource.clip = clip;
			newSource.loop = true;
			newSource.playOnAwake = true;
			newSource.volume = 0.5f;
			newSource.Play();
		}

	}
	void PlayBackgroundMusic() {
		backgroundSource.Play ();
	}

	public void LagoonTearDown(bool toMainMap) {
		AudioSource[] sources = gameObject.GetComponents<AudioSource>();
		foreach(AudioSource source in sources) {
			if(source != backgroundSource && source != SFXsource) {
				Destroy(source);
			}
		}
		if(toMainMap)
			PlayBackgroundMusic();
	}

}
