using UnityEngine;
using System.Collections;

public class fogo_script : MonoBehaviour {
	float delay = 10;
	int sort = 0;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (delay > 0) {
			delay -= Time.deltaTime;
		} else {
			GameObject instance = (GameObject)Instantiate(Resources.Load<GameObject>("fogo_criado2"), transform.position, Quaternion.identity);
			delay = 10;
		}
		
		//Instantiate(fogoGameObjectPrefab, transform.position = new Vector3(0f,0f,0f),Quaternion.identity);
	}
	
}
