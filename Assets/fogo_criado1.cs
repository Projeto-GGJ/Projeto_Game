using UnityEngine;
using System.Collections;

public class fogo_criado1 : MonoBehaviour {
	private float tempo = 0;
	private int frames = 8;
	private Vector3 direcao = new Vector3(0.07f,-0.035f,0f);
	private GameObject novo_fogo;
	private Vector3 pos;

		// Use this for initialization
	void Start () {
		novo_fogo = Resources.Load<GameObject>("fogo_criado1");
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (direcao);
		frames--;
		if (frames == 0){direcao = new Vector3 (0f, 0f, 0f);}
		tempo += Time.deltaTime;
		if (frames == 0) {
			Instantiate(novo_fogo, this.transform.position, Quaternion.identity);
		}
		
		pos = transform.position;
		
		if ((pos.x > 5.6f && pos.y < -0.5f)
		    ||(pos.x > 4.97f && pos.y < -0.815f)
		    ||(pos.x > 4.34f && pos.y < -1.13f)
 	   	    ||(pos.x > 3.71f && pos.y < -1.445f)
		    ||(pos.x > 3.08f && pos.y < -1.76f)
		    ||(pos.x > 2.45f && pos.y < -2.075f)
		    ||(pos.x > 1.82f && pos.y < -2.39f)
		    ||(pos.x > 1.19f && pos.y < -2.705f)
		    ||(pos.x > 0.56f && pos.y < -3.02f)
		    ||(pos.x > -0.07f && pos.y < -3.335f)
		    || (tempo > 0.75)) {
		   
			GameObject.Destroy(this.gameObject);
		}
	}
}