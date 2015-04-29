using UnityEngine;
using System.Collections;

public class EnemyBerserk : MonoBehaviour {

	public EnemyStats enemyStats;

	Vector3 target;
	bool charge;
	public bool berserk;

	float speed;
	
	// Use this for initialization
	void Start () {
		enemyStats = GetComponent<EnemyStats> ();
		speed = enemyStats.moveSpeed;

	}
	
	// Update is called once per frame
	void Update () {
		if (charge) {
			transform.position = Vector3.MoveTowards (transform.position, target, speed * Time.deltaTime);
			if (transform.position == target)
				charge = false;
		}

		if (enemyStats.health <= 4 && !berserk) {
			berserk = true;
			speed += .5f;
			enemyStats.healthRegen += 1f;
			enemyStats.Attack += 2;
			enemyStats.defense = 0;
		}

		if (enemyStats.health < 10)
			enemyStats.health += enemyStats.healthRegen * Time.deltaTime;

	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "Player") {
			target = col.transform.position;
			charge = true;
		}

	}
	
	void OnTriggerStay2D (Collider2D col) {
		if (col.tag == "Player" && !charge) {
			target = col.transform.position;
			charge = true;
		}
	}


}
