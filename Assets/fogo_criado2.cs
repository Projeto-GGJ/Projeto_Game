using UnityEngine;
using System.Collections;

public class fogo_criado2 : MonoBehaviour {
	private float tempo = 0;
	private int frames = 8;
	private Vector3 direcao = new Vector3(-0.07f,-0.035f,0f);
	private GameObject novo_fogo;
	private Vector3 pos;

	// Use this for initialization
	void Start () {
		novo_fogo = Resources.Load<GameObject>("fogo_criado2");
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
		
		if ((pos.x < -5.76f && pos.y < -0.45f)
		    ||(pos.x < -5.13f && pos.y < -0.765f)
		   	||(pos.x < -4.5f && pos.y < -1.08f)
		   	||(pos.x < -3.87f && pos.y < -1.395f)
		    ||(pos.x < -3.24f && pos.y < -1.71f)
		    ||(pos.x < -2.61f && pos.y < -2.025f)
		    ||(pos.x < -1.98f && pos.y < -2.34f)
		    ||(pos.x < -1.35f && pos.y < -2.655f)
		    ||(pos.x < -0.72f && pos.y < -2.97f)
		    ||(pos.x < -0.09f && pos.y < -3.285f)
		    || (tempo > 0.75) ) {
		    
			GameObject.Destroy(this.gameObject);
		}
	}
}