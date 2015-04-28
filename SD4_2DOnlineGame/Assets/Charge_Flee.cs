using UnityEngine;
using System.Collections;

public class Charge_Flee : MonoBehaviour {

	EnemyStats enemyStats;
	EnemyCharge enemyCharge;
	EnemyFlee enemyFlee;

	// Use this for initialization
	void Start () {
		enemyStats = GetComponent<EnemyStats>();
		enemyCharge = GetComponent<EnemyCharge>();
		enemyFlee = GetComponent<EnemyFlee>();
		enemyFlee.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (enemyStats.health <= 2)
		{
			enemyStats.health += enemyStats.healthRegen * Time.deltaTime;
			enemyCharge.enabled = false;
			enemyFlee.enabled = true;
		}
		else if ( enemyStats.health >= 10)
		{
			enemyCharge.enabled = true;
			enemyFlee.enabled = false;
		}

	}
}
