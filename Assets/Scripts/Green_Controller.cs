using UnityEngine;
using System.Collections;

public class Green_Controller : MonoBehaviour {

	Animator anim;
	float random;
	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator> ();
	}

	void FixedUpdate()
	{
		random = Random.Range (0f, 100f);

		if (random < 1f) 
		{
			anim.SetTrigger ("Blink");
		}
	}

	public void LeftArm (int state) 
	{
		if (state == 1) 
		{
			anim.SetTrigger ("LeftArm");
		} 
	}

	public void Mouth(int state)
	{
		if (state == 1) 
		{
			anim.SetTrigger ("Mouth");
		} 
	}

	public void Chew (int state)
	{
		if (state == 1)
		{
			anim.SetTrigger ("Chewing");
		}
	}
}
