using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoPlay;
	
	private Ball ball;
	
	// Use this for initialization
	void Start () {
		ball=GameObject.FindObjectOfType<Ball>();

	}
	
	// Update is called once per frame
	void Update () {
		if (!autoPlay) {
			mousePlay();
		} else {
			automaticPlay();
		}
	}
	
	void OnCollisionEnter2D(Collision2D collision) {
		Vector2 tweak = new Vector2(Random.Range (-1f,1f), Random.Range (0.1f,0.5f));
		ball.rigidbody2D.velocity += tweak;
	}
	
	void mousePlay () {
		float mousePosInBlocks = Input.mousePosition.x / 800 * 16;
		Vector3 paddlePos = new Vector3 (Mathf.Clamp (mousePosInBlocks, 0.87f,15.13f), this.transform.position.y, 0f);
		this.transform.position = paddlePos;
	}
	
	void automaticPlay() {
		float ballPos = ball.transform.position.x;
		Vector3 paddlePos = new Vector3 (ballPos, this.transform.position.y, 0f);
		this.transform.position = paddlePos;
	}
}
