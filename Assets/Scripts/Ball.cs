using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	
	public bool hasStarted = false;
	public static int bounce;
	
	private Paddle paddle;
	private Vector3 paddleToBall;
	
	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBall = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(!hasStarted){
			this.transform.position = paddle.transform.position + paddleToBall;
			if(Input.GetMouseButtonDown(0)) {
				this.rigidbody2D.velocity = new Vector2(Random.Range (-3f, 4f),10f);
				hasStarted = true;
			}
		}
	}
	
	void OnCollisionEnter2D(Collision2D col) {
		bounce++;
		if (bounce >= 2) {
			audio.Play ();
		}
	}	
}
