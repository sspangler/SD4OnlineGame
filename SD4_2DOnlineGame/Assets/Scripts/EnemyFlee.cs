using UnityEngine;
using System.Collections;

public class EnemyFlee : MonoBehaviour {

	public EnemyStats enemyStats;
	
	Vector3 target;
	bool run;

	float speed;

	float counter = 2f;

	Vector3 direction;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (run) {
			counter -= Time.deltaTime;
			transform.Translate(direction);
			if (counter <= 0)
				run = false;
		}
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "Player") {
			direction = col.transform.position - transform.position;
			run = true;
		}
	}
	
	void OnTriggerStay2D (Collider2D col) {
		if (col.tag == "Player" && counter <= 0) {
			direction = col.transform.position - transform.position;
			run = true;
			counter = 2f;
		}
	}
}
