using UnityEngine;
using System.Collections;

public class EnemyStats : MonoBehaviour {

	public bool isBoss;
	public float health;
	public float healthRegen;
	public float moveSpeed;
	public float Attack;
	public float attackSpeed;
	public float defense;

	public float experience; //xp given to play on death

	[HideInInspector]
	public float diffMod = 1;
	public float distance;
	// Use this for initialization
	void Start () {

		distance = transform.position.magnitude / 100;
		if (distance >= 1)
			diffMod = distance;

		if (isBoss) {
			health = health * 1.5f;
			healthRegen = healthRegen * 1.2f;
			Attack = Attack * 1.5f;
			attackSpeed = attackSpeed * 1.2f;
			defense = defense * 1.25f;
		}

		health = health * diffMod;
		healthRegen = healthRegen * diffMod;
		moveSpeed = moveSpeed * diffMod;
		Attack = Attack * diffMod;
		attackSpeed = attackSpeed * diffMod;
		defense = defense * diffMod;
		experience = experience * diffMod;
	}

	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == "PlayerBullet") {
			GetComponent<Rigidbody2D>().velocity = Vector3.zero;
			GetComponent<Rigidbody2D>().angularVelocity = 0;
			health -= col.gameObject.GetComponent<playerBullet>().damage;
			if (health <= 0) {
				Destroy(gameObject);
				playerBullet colBullet = col.gameObject.GetComponent<playerBullet>();
				colBullet.playerScript.currEXP += experience;
				if (colBullet.playerScript.currEXP  >= colBullet.playerScript.nextLevelEXP)
					colBullet.playerScript.level += 1;
			}
			Destroy(col.gameObject);
		}
	}
}
