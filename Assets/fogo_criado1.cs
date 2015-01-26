using UnityEngine;
using System.Collections;

public class fogo_criado1 : MonoBehaviour {
	private float tempo = 0;
	private int frames = 8;
	private Vector3 direcao = new Vector3(0.07f,-0.035f,0f);

		// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (direcao);
		frames--;
		if (frames == 0){direcao = new Vector3 (0f, 0f, 0f);}
		tempo += Time.deltaTime;
		if (frames == 0) {
			GameObject instance = (GameObject)Instantiate(Resources.Load<GameObject>("fogo_criado1"), this.transform.position, Quaternion.identity);
		}
		
		if (tempo > 0.75) {
			GameObject.Destroy(this.gameObject);
		}
	}
}
