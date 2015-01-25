using UnityEngine;
using System.Collections;

public class personagem : MonoBehaviour {
	private int max_pos_x = 5;
	private int max_pos_y = 4;
	//float delta_y = 0;
	//float delta_x = 0;
	private int personagem_x = 0;
	private int personagem_y = 0;
	private Vector3 direcao;
	private int frames = 0;
	private bool pode_andar = true;
	private bool pode_cima = true;
	private bool pode_direita = true;
	private bool pode_baixo = true;
	private bool pode_esquerda = true;
	private Animator animador;

	// Use this for initialization
	void Start () {
		animador = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		//movimentacao2 ();
		movimentacao1_pt1 ();
		movimentacao1_pt2 ();
	}

	private void movimentacao1_pt1(){
		if (Input.GetKeyDown (KeyCode.UpArrow)&& personagem_y < max_pos_y && pode_cima && pode_andar) {
			pode_andar = false;
			personagem_y++;
			frames = 8;
			animador.SetBool("andando_tras", true );
			transform.localScale = new Vector3(4F, 4F, 0);
			direcao = new Vector3(0.07f,0.035f,0f);
		}
		if (Input.GetKeyDown (KeyCode.DownArrow) && personagem_y >= max_pos_y*(-1) && pode_baixo && pode_andar) {
			pode_andar = false;
			personagem_y--;
			frames = 8;
			animador.SetBool("andando_frente", true );
			transform.localScale = new Vector3(4F, 4F, 0);
			direcao = new Vector3(-0.07f,-0.035f,0f);
		}
		if (Input.GetKeyDown (KeyCode.LeftArrow) && personagem_x > max_pos_x*(-1) + 1 && pode_esquerda && pode_andar) {
			pode_andar = false;	
			personagem_x--;
			frames = 8;
			animador.SetBool("andando_tras", true );
			transform.localScale = new Vector3(-4F, 4F, 0);
			direcao = new Vector3(-0.07f,0.035f,0f);
		}
		if (Input.GetKeyDown (KeyCode.RightArrow) && personagem_x < max_pos_x && pode_direita && pode_andar) {
			pode_andar = false;
			personagem_x++;
			frames = 8;
			animador.SetBool("andando_frente", true );
			transform.localScale = new Vector3(-4F, 4F, 0);
			direcao = new Vector3(0.07f,-0.035f,0f);
		}
		if (Input.GetKeyDown (KeyCode.X) && pode_andar) {
			animador.SetBool("put", true );
			pode_andar = false;
			frames = 8;
		}
	}
	private void movimentacao1_pt2(){
		transform.Translate (direcao);
		if (frames == 0) {
			direcao = new Vector3 (0f, 0f, 0f);
			pode_andar = true;
			animador.SetBool("andando_frente", false );
			animador.SetBool("andando_tras", false );
			animador.SetBool("put", false );
		}
		else {
			frames--;
		}
	}
/*
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
*/
	void OnTriggerExit2D(Collider2D objeto) {
	pode_cima = true;
	pode_baixo = true;
	pode_esquerda = true;
	pode_direita = true;
}

	void OnTriggerStay2D(Collider2D objeto) {
		if (objeto.name == "fogo") {
			Debug.Log("fogo!!!!!!");
		}
		if (objeto.name == "agua") {
			Debug.Log("agua!!!!!!");
		}
		/*
		if (objeto.transform.position.y > transform.position.y - 0.05f && objeto.transform.position.y < transform.position.y + 0.02f ) {
			if (objeto.transform.position.x > transform.position.x)
			{pode_cima = false;}
			else{pode_esquerda = false;}
		}
		else if (objeto.transform.position.y > transform.position.y - 0.815f && objeto.transform.position.y < transform.position.y - 0.795f) {
			if (objeto.transform.position.x > transform.position.x) {
				pode_direita = false;
			} else {
				pode_baixo = false;
			}
		}
		else{pode_cima = true;pode_esquerda = true;pode_direita = true;pode_baixo = true;}
		*/
	}

}