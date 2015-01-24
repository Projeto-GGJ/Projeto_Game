using UnityEngine;
using System.Collections;

public class controledelayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerStay2D(Collider2D objeto) {
		Debug.Log (objeto.name);
		if (objeto.transform.position.y > transform.position.y) {
			objeto.renderer.sortingOrder = 1;
			renderer.sortingOrder = 2;
		} else {
			objeto.renderer.sortingOrder = 2;
			renderer.sortingOrder = 1;
		}
	}
}
