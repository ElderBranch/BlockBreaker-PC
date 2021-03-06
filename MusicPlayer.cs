﻿using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	static MusicPlayer instance = null;
	
	void Awake (){
		Debug.Log("Music Player Awake " + GetInstanceID());
		if(instance != null){
			Destroy(gameObject);
			print ("Music Player self auto destroyed");
		}else{
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}
}
