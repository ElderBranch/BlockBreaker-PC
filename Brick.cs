using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	
	public AudioClip crack;
	public Sprite[] hitSprites;
	public GameObject Smoke;
	public SpriteRenderer smokePuff;
	public static int breakableCount = 0;
	
	private int maxHits;
	private bool isBreackable;
	private int timesHit;
	private LevelManager levelManager;

	// Use this for initialization
	void Start () {
		isBreackable = (this.tag == "Breackable");
		// Keep track of breackables bricks
		if(isBreackable){
			breakableCount++;
		}
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		timesHit = 0;
		print (breakableCount);
	}
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter2D (Collision2D col) {
		if(isBreackable) {
			HandleHits();
		}	
	}
	
	void HandleHits (){
		timesHit++;
		maxHits = hitSprites.Length + 1;
		if(maxHits <= timesHit){
			breakableCount--;
			levelManager.brickDestroyed();
			Destroy(gameObject);
			AudioSource.PlayClipAtPoint (crack, transform.position);
			GameObject smokePuff = Instantiate(Smoke, transform.position, Quaternion.identity) as GameObject;
			smokePuff.particleSystem.startColor = gameObject.GetComponent<SpriteRenderer>().color;
		
		} else {
			LoadSprites();
		}
	}
	
	void LoadSprites(){
		int spriteIndex = timesHit - 1;
		if(hitSprites[spriteIndex] != null){
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		} else {
			Debug.LogError("Brick sprite missing");
		}
	}
}
