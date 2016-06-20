using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D trigger){
		Application.LoadLevel("Lose");
		
	}
	
	void OnCollisionEnter2D (Collision2D collision){
		print("Collision activated");
	}
}
