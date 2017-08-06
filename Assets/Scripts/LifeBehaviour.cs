using UnityEngine;
using System.Collections;

public class LifeBehaviour : MonoBehaviour {

	public Sprite[] lifeDisplay;
	
	
	void Update () {
		lifeSprite();
	}
	
	public void lifeSprite () {
		int lifeIndex = LoseCollider.lifeNumber - 1;
		if (lifeDisplay[lifeIndex]) {
			this.GetComponent<SpriteRenderer>().sprite = lifeDisplay[lifeIndex];
		} else {
			Debug.LogError ("No Sprite Loaded");
		}
	}
	
}
