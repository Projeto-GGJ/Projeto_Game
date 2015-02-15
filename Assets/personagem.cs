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
	private bool balde = false;
	private bool atualizacao = true;
	private bool agua = false;
	private int lado = 1;
	private GameObject[] achar_fogos;
	

	// Use this for initialization
	void Start () {
		animador = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		atualizacao = true;
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
			lado = 2;
		}
		if (Input.GetKeyDown (KeyCode.DownArrow) && personagem_y >= max_pos_y*(-1) && pode_baixo && pode_andar) {
			pode_andar = false;
			personagem_y--;
			frames = 8;
			animador.SetBool("andando_frente", true );
			transform.localScale = new Vector3(4F, 4F, 0);
			direcao = new Vector3(-0.07f,-0.035f,0f);
			lado = 1;
		}
		if (Input.GetKeyDown (KeyCode.LeftArrow) && personagem_x > max_pos_x*(-1) + 1 && pode_esquerda && pode_andar) {
			pode_andar = false;	
			personagem_x--;
			frames = 8;
			animador.SetBool("andando_tras", true );
			transform.localScale = new Vector3(-4F, 4F, 0);
			direcao = new Vector3(-0.07f,0.035f,0f);
			lado = 3;
		}
		if (Input.GetKeyDown (KeyCode.RightArrow) && personagem_x < max_pos_x && pode_direita && pode_andar) {
			pode_andar = false;
			personagem_x++;
			frames = 8;
			animador.SetBool("andando_frente", true );
			transform.localScale = new Vector3(-4F, 4F, 0);
			direcao = new Vector3(0.07f,-0.035f,0f);
			lado = 4;
		}
		if (Input.GetKeyDown (KeyCode.X) && pode_andar) {
			atualizacao = false;
			balde = true;
			animador.SetBool("put", true );
			pode_andar = false;
			frames = 8;
			animador.SetBool("water", false );
			if (agua) {
				achar_fogos = GameObject.FindGameObjectsWithTag("fogo");
				foreach (GameObject fogo in achar_fogos) {
					if (lado == 1
					 && fogo.transform.position.x <= this.transform.position.x - 0.70f
					 && fogo.transform.position.x >= this.transform.position.x - 0.74f
					 && fogo.transform.position.y <= this.transform.position.y - 0.43f
					 && fogo.transform.position.y >= this.transform.position.y - 0.47f) {
						GameObject.Destroy(fogo.gameObject);				
					} else if (lado == 2
					 && fogo.transform.position.x >= this.transform.position.x + 0.52f
					 && fogo.transform.position.x <= this.transform.position.x + 0.56f
					 && fogo.transform.position.y >= this.transform.position.y + 0.16f
					 && fogo.transform.position.y <= this.transform.position.y + 0.2f) {
						GameObject.Destroy(fogo.gameObject);
					} else if (lado == 3
				     && fogo.transform.position.x >= this.transform.position.x - 0.74f
				     && fogo.transform.position.x <= this.transform.position.x - 0.70f
				     && fogo.transform.position.y >= this.transform.position.y + 0.16f
				     && fogo.transform.position.y <= this.transform.position.y + 0.2f) {
						GameObject.Destroy(fogo.gameObject);
					} else if (lado == 4
					 && fogo.transform.position.x >= this.transform.position.x + 0.52f
					 && fogo.transform.position.x <= this.transform.position.x + 0.56f
					 && fogo.transform.position.y <= this.transform.position.y - 0.43f
					 && fogo.transform.position.y >= this.transform.position.y - 0.47f) {
						GameObject.Destroy(fogo.gameObject);
					}
				}
			}
			agua = false;
		}
	}
	
	private void movimentacao1_pt2(){
		transform.Translate (direcao);
		if (frames == 0) {
			direcao = new Vector3 (0f, 0f, 0f);
			pode_andar = true;
			balde = false;
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
/*
	void OnTriggerExit2D(Collider2D objeto) {
	pode_cima = true;
	pode_baixo = true;
	pode_esquerda = true;
	pode_direita = true;
}*/

	void OnTriggerStay2D(Collider2D objeto) {
		if (objeto.name.Contains("fogo")) {
			Application.LoadLevel("credits");
		}
		
		if (balde && atualizacao && objeto.name == "agua") {
			agua = true;
			animador.SetBool("water", true );
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