using UnityEngine;
using System.Collections;

/* Controls the audio for different scenes. Sends either new background music or a
 * clip to be played to the SoundManager.
 */

public class SceneSound : MonoBehaviour {

	private GameObject SoundManager;
	private AudioSource[] Audio;
	private AudioSource SFX;
	private AudioSource Background;

	public AudioClip BackgroundMusic;

	void Awake () {
		ChangeBackgroundMusic (BackgroundMusic);
	}

	public void PlayClip( AudioClip clip)
	{
		SoundManager = GameObject.Find ("SoundManager");
		Audio = SoundManager.GetComponents<AudioSource> ();
		SFX = Audio [1];
		SFX.clip = clip;
		SFX.Play ();
	}

	public void ChangeBackgroundMusic ( AudioClip clip)
	{
		SoundManager = GameObject.Find ("SoundManager");
		Audio = SoundManager.GetComponents<AudioSource> ();
		Background = Audio [0];

		if (Background.clip != clip) 
		{
				Background.clip = clip;
				Background.Play ();
		}

	} 
}

