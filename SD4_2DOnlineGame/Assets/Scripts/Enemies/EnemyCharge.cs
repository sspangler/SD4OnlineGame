using UnityEngine;
using System.Collections;

public class EnemyCharge : MonoBehaviour {

	public EnemyStats enemyStats;

	Vector3 target;
	bool charge;

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
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "Player" && col.GetType() == typeof(CircleCollider2D)) {
			target = col.transform.position;
			charge = true;
		}
	}

	void OnTriggerStay2D (Collider2D col) {
		if (col.tag == "Player" && !charge && col.GetType() == typeof(CircleCollider2D)) {
			target = col.transform.position;
			charge = true;
		}
	}
}