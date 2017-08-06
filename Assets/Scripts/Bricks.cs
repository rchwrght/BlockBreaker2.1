using UnityEngine;
using System.Collections;

public class Bricks : MonoBehaviour {

	public static int breakCount = 0;
	public int maxHits;
	public Sprite[] hitSprites;
	
	private bool isBreakable;
	private LevelManager levelManager;
	private int hitCount;
	
	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		if (isBreakable) {
			breakCount++;
		}
	}
	
	// Update is called once per frame
	void Update () {
		print (breakCount);
	}
	
	void OnCollisionEnter2D(Collision2D collision) {
		countHits ();
		if (hitCount >= maxHits) {
			levelManager = GameObject.FindObjectOfType<LevelManager>();
			breakCount--;
			Destroy(gameObject);
			levelManager.brickDestroyed();
		} else {
			LoadSprite();
		}
	}
	
	void countHits () {
		hitCount++;
	}
	
	void LoadSprite () {
		int spriteIndex = hitCount - 1;
		if(hitSprites[spriteIndex]) {
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		} else {
			Debug.LogError("No Sprite Detected");
		}
	}
}
