﻿using UnityEngine;
using System.Collections;

public class fogo_script2 : MonoBehaviour {
	float delay = 10;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (delay > 0) {
			delay -= Time.deltaTime;
		} else {
			Instantiate(Resources.Load<GameObject>("fogo_criado1"), transform.position, Quaternion.identity);
			delay = 10;
		}
	}
}
