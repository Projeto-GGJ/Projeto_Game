using UnityEngine;
using System.Collections;

public class camera : MonoBehaviour {
	private Transform principal;
	// Use this for initialization
	void Start () {
		principal = (Transform)GameObject.Find ("personagem").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		if (principal.transform.position.y < -2) {
			transform.position = new Vector3 (0f, -5f, -11f);
		} else {
			transform.position = new Vector3 (0f, 0f, -11f);
		}
	}
}
