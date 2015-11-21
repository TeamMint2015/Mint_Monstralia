using UnityEngine;
using System.Collections;

public class Green_Controller : MonoBehaviour {

	Animator anim;
	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator> ();
	}

	public void LeftArm (int state) 
	{
		if (state == 1) 
		{
			anim.SetBool ("LeftArm", true);
		} 
		else 
		{
			anim.SetBool ("LeftArm", false);
		}
	}

	public void Mouth(int state)
	{
		if (state == 1) 
		{
			anim.SetBool ("Mouth", true);
		} 
		else 
		{
			anim.SetBool ("Mouth", false);
		}
	}
}
