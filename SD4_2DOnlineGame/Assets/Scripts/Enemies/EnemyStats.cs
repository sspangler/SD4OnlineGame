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

		distance = transform.position.magnitude / 100f;
		if (distance >= 1)
			diffMod = distance;

		if (isBoss) {
			health = health * 1.5f;
			healthRegen = healthRegen * 1.2f;
			Attack = Attack * 1.5f;
			attackSpeed = attackSpeed * 1.2f;
			defense = defense * 1.2f;
		}

		health = health * diffMod;
		healthRegen = healthRegen * (diffMod * 0.5f);
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
			transform.eulerAngles = Vector3.zero;
            float dmg = col.gameObject.GetComponent<playerBullet>().damage - defense;
            if (dmg < 1) dmg = 1;
            health -= dmg;
			if (health <= 0) {
				Destroy(gameObject);
				playerBullet colBullet = col.gameObject.GetComponent<playerBullet>();
				colBullet.playerScript.currEXP += (int) experience;
                //if (colBullet.playerScript.currEXP >= colBullet.playerScript.nextLevelEXP)
                //{
                //    colBullet.playerScript.level += 1;
                //    colBullet.playerScript.nextLevelEXP = colBullet.playerScript.nextLevelEXP * 2;
                //}
			}
			Destroy(col.gameObject);
		}
	}
}
