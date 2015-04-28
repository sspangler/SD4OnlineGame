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

	// Use this for initialization
	void Start () {
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
	
	// Update is called once per frame
	void Update () {

	}
}
