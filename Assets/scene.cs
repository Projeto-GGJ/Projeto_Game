using UnityEngine;
using System.Collections;

public class scene : MonoBehaviour {
	private Vector3[] posicoes;
	private float x_atual = -5.76f;
	private float y_atual = -0.45f;
	private float delay = 0;
	private float tempos = 0;
	private float cooldown = 10;
	
	// Use this for initialization
	void Start () {
	}
	
	void Awake() {
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
			GameObject instance = (GameObject)Instantiate(Resources.Load<GameObject>("fogo_prefab"), posicoes[(int) Mathf.RoundToInt(Random.Range(0,18))], Quaternion.identity);
		}
	}
}
