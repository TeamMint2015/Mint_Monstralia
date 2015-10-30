using UnityEngine;
using System;

public class BrainbowFood : Food {

	private Vector3 offset;
	private Vector3 screenPoint;
	private Transform origin;
	private bool busy;
	private bool moving;

	public LayerMask layerMask;
	
	// Use this for initialization
	void Start () {
		busy = false;
		moving = false;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown() {
		if(!busy) {
			moving = true;
			BrainbowGameManager.GetInstance().SetActiveFood(this);
			offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
		}
	}
	
	void FixedUpdate() {
		if(moving) {
			Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
			Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
			gameObject.GetComponent<Rigidbody2D>().MovePosition(curPosition);
		}
	}

	void OnMouseUp() {
		if(!busy && moving) {
			busy = true;

			RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 1.0f, layerMask);

			if(hit.collider != null && hit.collider.gameObject.GetComponent<ColorDetector>().color == this.color) {
				ColorDetector detector = hit.collider.gameObject.GetComponent<ColorDetector>();
				SoundManager.GetInstance().PlayClip(BrainbowGameManager.GetInstance().correctSound);
				detector.AddFood(gameObject);
				Destroy(gameObject.GetComponent<Collider2D>());
				BrainbowGameManager.GetInstance().Replace(gameObject);
			}
			else {
				MoveBack ();
			}
		}
		moving = false;
		busy = false;
	}

	public void SetOrigin(Transform origin) {
		this.origin = origin;
	}

	public Transform GetOrigin() {
		return origin;
	}

	void MoveBack () {
		gameObject.transform.position = GetOrigin ().position;
		SoundManager.GetInstance ().PlayClip (BrainbowGameManager.GetInstance ().incorrectSound);
	}

	public void StopMoving() {
		busy = true;
		gameObject.transform.position = GetOrigin().position;
	}
}
