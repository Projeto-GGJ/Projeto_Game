using UnityEngine;
using System.Collections;

public class personagem : MonoBehaviour {
	int max_pos_x = 2;
	int max_pos_y = 2;
	float delta_y = 0;
	float delta_x = 0;
	int personagem_x = 0;
	int personagem_y = 0;
	Vector3 direcao;
	int frames = 0;
	bool pode_andar = true;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		//movimentacao2 ();
		movimentacao1_pt1 ();
		movimentacao1_pt2 ();
	}

	void movimentacao1_pt1(){
		if (Input.GetKeyDown (KeyCode.UpArrow)&& personagem_y < max_pos_y && pode_andar == true) {
			pode_andar = false;
			personagem_y++;
			frames = 8;
			direcao = new Vector3(0.179f,0.09f,0f);
		}
		if (Input.GetKeyDown (KeyCode.DownArrow) && personagem_y > max_pos_y*(-1) && pode_andar == true) {
			pode_andar = false;
			personagem_y--;
			frames = 8;
			direcao = new Vector3(-0.179f,-0.09f,0f);
		}
		if (Input.GetKeyDown (KeyCode.LeftArrow) && personagem_x > max_pos_x*(-1) && pode_andar == true) {
			pode_andar = false;	
			personagem_x--;
			frames = 8;
			direcao = new Vector3(-0.179f,0.09f,0f);
		}
		if (Input.GetKeyDown (KeyCode.RightArrow) && personagem_x < max_pos_x && pode_andar == true) {
			pode_andar = false;
			personagem_x++;
			frames = 8;
			direcao = new Vector3(0.179f,-0.09f,0f);
		}
	}
	void movimentacao1_pt2(){
		transform.Translate (direcao);
		if (frames == 0) {
			direcao = new Vector3 (0f, 0f, 0f);
			pode_andar = true;
		}
		else {
			frames--;
			//Debug.Log (name+" "+transform.position.y);
		}
	}

	void movimentacao2(){
		if (Input.GetKey (KeyCode.UpArrow) && delta_y < 3.2) {
			transform.Translate(0.179f,0.09f,0f);
			delta_y += 0.179f;
			//Debug.Log (name+" "+transform.position.y);
		}
		if (Input.GetKey (KeyCode.DownArrow) && delta_y > -3.2) {
			transform.Translate(-0.179f,-0.09f,0f);
			delta_y -= 0.179f;
			//Debug.Log (name+" "+transform.position.y);
		}
		if (Input.GetKey (KeyCode.LeftArrow) && delta_x > -1.6) {
			transform.Translate(-0.179f,0.09f,0f);
			delta_x -= 0.09f;
			//Debug.Log (name+" "+transform.position.y);
		}
		if (Input.GetKey (KeyCode.RightArrow) && delta_x < 1.6) {
			transform.Translate(0.179f,-0.09f,0f);
			delta_x += 0.09f;
			//Debug.Log (name+" "+transform.position.y);
		}
	}

	void OnTriggerEnter2D(Collider2D objeto) {
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
