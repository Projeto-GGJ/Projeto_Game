using UnityEngine;
using System.Collections;

public class controledelayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	void Awake (){
		//Debug.Log (name + " " + transform.position);
	}

	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D objeto) {
		if (objeto.transform.position.y + 0.25 > transform.position.y) {
			objeto.renderer.sortingOrder = 1;
			renderer.sortingOrder = 2;
		} else {
			objeto.renderer.sortingOrder = 2;
			renderer.sortingOrder = 1;
		}
	}

	void OnTriggerStay2D(Collider2D objeto) {
		if (objeto.transform.position.y + 0.25 > transform.position.y) {
			objeto.renderer.sortingOrder = 1;
			renderer.sortingOrder = 2;
		} else {
			objeto.renderer.sortingOrder = 2;
			renderer.sortingOrder = 1;
		}
	}
}
