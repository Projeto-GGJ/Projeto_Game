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
	bool pode_cima = true;
	bool pode_direita = true;
	bool pode_baixo = true;
	bool pode_esquerda = true;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		movimentacao2 ();
		//movimentacao1_pt1 ();
		//movimentacao1_pt2 ();
	}

	void movimentacao1_pt1(){
		if (Input.GetKeyDown (KeyCode.UpArrow)&& personagem_y < max_pos_y && pode_andar) {
			pode_andar = false;
			personagem_y++;
			frames = 8;
			direcao = new Vector3(0.179f,0.09f,0f);
		}
		if (Input.GetKeyDown (KeyCode.DownArrow) && personagem_y > max_pos_y*(-1) && pode_andar) {
			pode_andar = false;
			personagem_y--;
			frames = 8;
			direcao = new Vector3(-0.179f,-0.09f,0f);
		}
		if (Input.GetKeyDown (KeyCode.LeftArrow) && personagem_x > max_pos_x*(-1) && pode_andar) {
			pode_andar = false;	
			personagem_x--;
			frames = 8;
			direcao = new Vector3(-0.179f,0.09f,0f);
		}
		if (Input.GetKeyDown (KeyCode.RightArrow) && personagem_x < max_pos_x && pode_andar) {
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
		}
	}

	void movimentacao2(){
		if (Input.GetKeyDown (KeyCode.UpArrow) && delta_y < 3.2 && pode_cima) {
			transform.Translate(0.179f,0.09f,0f);
			delta_y += 0.179f;
			Debug.Log(transform.position);
		}
		if (Input.GetKeyDown (KeyCode.DownArrow) && delta_y > -3.2 && pode_baixo) {
			transform.Translate(-0.179f,-0.09f,0f);
			delta_y -= 0.179f;
			Debug.Log(transform.position);
		}
		if (Input.GetKeyDown (KeyCode.LeftArrow) && delta_x > -1.6 && pode_esquerda) {
			transform.Translate(-0.179f,0.09f,0f);
			delta_x -= 0.09f;
			Debug.Log(transform.position);
		}
		if (Input.GetKeyDown (KeyCode.RightArrow) && delta_x < 1.6 && pode_direita) {
			transform.Translate(0.179f,-0.09f,0f);
			delta_x += 0.09f;
			Debug.Log(transform.position);
		}
	}

	void OnTriggerStay2D(Collider2D objeto) {

		if (objeto.transform.position.y > transform.position.y ) {
			pode_esquerda = false;
		} else {
			pode_esquerda = true;
		}
	}
}
