using UnityEngine;
using System.Collections;

public class BossSpawner : MonoBehaviour {

	public EnemyStats enemyStats;

	public GameObject[] minions;
	public int spawnsPerVolly;
	float spawnSpeed;
	float spawnCounter;
	bool spawning;
	float speed;
	Vector3 vel;
	// Use this for initialization
	void Start () {
		enemyStats = GetComponent<EnemyStats> ();
		spawnSpeed = enemyStats.attackSpeed;
		spawnCounter = spawnSpeed;
		speed = enemyStats.moveSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		if (spawning) {
			spawnCounter -= Time.deltaTime;
			if (spawnCounter <= 0) {
				Spawn();
				vel = Random.insideUnitSphere * speed;
				vel.z = 0.0f;
			}
			transform.Translate (vel * Time.deltaTime);
		}

	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "Player" && col.GetType() == typeof(CircleCollider2D)) {
			spawning = true;
		}
	}

	void OnTriggerExit2D (Collider2D col) {
		if (col.tag == "Player" && col.GetType() == typeof(CircleCollider2D)) {
			spawning = false;
		}
	}

	void Spawn () {
		int randomNum = Random.Range (0, minions.Length);
		Instantiate (minions [randomNum], transform.position, Quaternion.identity);
		spawnCounter = spawnSpeed;
		vel = Vector3.zero;
	}
}
