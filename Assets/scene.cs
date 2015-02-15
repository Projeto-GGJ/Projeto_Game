using UnityEngine;
using System.Collections;

public class scene : MonoBehaviour {
	private Vector3[] posicoes;
	private int index;
	private bool pode_criar;
	private float x_atual = -5.76f;
	private float y_atual = -0.45f;
	private float delay = 0;
	private float tempos = 0;
	private float cooldown = 10;
	private GameObject novo_fogo;
	private GameObject novo_fogo2;
	private GameObject[] achar_fogos;
	
	// Use this for initialization
	void Start () {
	}
	
	void Awake() {
		novo_fogo = Resources.Load<GameObject>("fogo_prefab1");
		novo_fogo2 = Resources.Load<GameObject>("fogo_prefab2");
		posicoes = new Vector3[19];
		posicoes[0] = new Vector3(x_atual,y_atual,0);
		
		for (int i = 0; i < 9; i++) {
			x_atual += 0.63f;
			y_atual += 0.315f;
			posicoes[i+1] = new Vector3(x_atual,y_atual,0);
		}
		
		for (int i = 9; i < 18; i++) {
			x_atual += 0.63f;
			y_atual -= 0.315f;
			posicoes[i+1] = new Vector3(x_atual,y_atual,0);
		}		
	}
	// Update is called once per frame
	void Update () {
		if (delay <= cooldown) {
			delay += Time.deltaTime;
			tempos += Time.deltaTime;
			
		} else {
			if (tempos >=30) {
				tempos = 0;
				cooldown--;
			}
			delay = 0;
			index = (int) Mathf.RoundToInt(Random.Range(0,18));
			achar_fogos = GameObject.FindGameObjectsWithTag("fogo");

			foreach (GameObject fogo in achar_fogos) {
				if (fogo.transform.position == posicoes[index]) {
					pode_criar = false;
				}
			}
			if (pode_criar && index > 8) {
				Instantiate(novo_fogo, posicoes[index], Quaternion.identity);
			}
			if (pode_criar && index < 10) {
				Instantiate(novo_fogo2, posicoes[index], Quaternion.identity);
			}
			pode_criar = true;
		}
	}
}
