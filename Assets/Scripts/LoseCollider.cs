using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	public static int lifeNumber = 3;
	
	private LevelManager levelManager;
	private Ball ball;
	
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
	}
	
	void OnTriggerEnter2D(Collider2D trigger) {
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		lifeNumber--;
		if (lifeNumber <= 0) {
			levelManager.LoadLevel("Lose");
		} else {
			ball.hasStarted = false;
		}
	}
	/*void OnCollisionEnter2D(Collision2D collision) {
		print ("collide");
	}*/
}
