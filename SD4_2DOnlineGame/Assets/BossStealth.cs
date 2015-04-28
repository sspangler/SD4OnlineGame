using UnityEngine;
using System.Collections;

public class BossStealth : MonoBehaviour {

	public EnemyStats enemyStats;
	
	Vector3 target;
	float speed;

	bool stalk;
	float timeToAttack = 0;
	GameObject player;

	// Use this for initialization
	void Start () {
		enemyStats = GetComponent<EnemyStats> ();
		speed = enemyStats.moveSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		if (stalk) {
			timeToAttack -= Time.deltaTime;
			if (timeToAttack <= 0)
			{

			}
		}

	}

	void Attack () {
		transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
	}


	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "Player") {
			stalk = true;
			player = col.gameObject;
		}
	}
}
