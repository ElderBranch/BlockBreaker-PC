using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	
	public Paddle paddle;
	
	private bool HasEstarted = false;
	private int maxPresses = 0;
	private Vector3 paddleToBall;
	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBall = this.transform.position - paddle.transform.position;
		print(paddleToBall.y);
	}
	
	// Update is called once per frame
	void Update () {
		if(maxPresses <= 0){
			Press();
		}
	}
	
	
	public void Press() {
		if(!HasEstarted){
			this.transform.position = paddle.transform.position + paddleToBall;
		}
		
		if(Input.GetMouseButtonDown(0)){
			maxPresses++;
			print(maxPresses);
			HasEstarted = true;
			this.rigidbody2D.velocity = new Vector2 (2f, 12f);
			
		}
	}
	
	void OnCollisionEnter2D(Collision2D	collision){
		Vector2 tweak = new Vector2(Random.Range(-0.2f, 0.2f), Random.Range(0f, 0f));
		if(HasEstarted){
			audio.Play();
			rigidbody2D.velocity += tweak;
		}	
	}
}
