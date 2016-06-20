using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoPlay;

	// Update is called once per frame
	void Update () {
		if(!autoPlay){
			PlayWithMouse();
		}
	}
	
	void PlayWithMouse(){
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		paddlePos.x = Mathf.Clamp(mousePosInBlocks, 1.25f, 12.05f);
		this.transform.position = paddlePos;
	}	
}
