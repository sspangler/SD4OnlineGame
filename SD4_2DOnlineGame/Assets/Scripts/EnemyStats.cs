using UnityEngine;
using System.Collections;

public class EnemyStats : MonoBehaviour {

	public float health;
	public float healthRegen;
	public float moveSpeed;
	public float Attack;
	public float attackSpeed;
	public float defense;

	public float experience; //xp given to play on death

	float diffMod = 1;

	// Use this for initialization
	void Start () {
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
