using UnityEngine;
using System.Collections;

public class EnemyShooter : MonoBehaviour {
	
	public EnemyStats enemyStats;

	public GameObject projectile;

	Vector3 target;
	float attackSpeed;
	float attackCounter;
	bool shoot;

	// Use this for initialization
	void Start () {
		enemyStats = GetComponent<EnemyStats> ();
		attackSpeed = enemyStats.attackSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		if (shoot) { 
			attackCounter -= Time.deltaTime;
			if (attackCounter <= 0)
				SpawnProjectile();
		}

	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "Player") {
			target = col.transform.position;
			shoot = true;
		}
	}
	
	void OnTriggerStay2D (Collider2D col) {
		if (col.tag == "Player") {
			target = col.transform.position;
			shoot = true;
		}
	}

	void SpawnProjectile () {
		GameObject clone = (GameObject) Instantiate (projectile, transform.position, Quaternion.identity);
		clone.GetComponent<Projectiles> ().target = target;
		attackCounter = attackSpeed;
	}
}
