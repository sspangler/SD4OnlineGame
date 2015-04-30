using UnityEngine;
using System.Collections;

public class SpawnEnemies : MonoBehaviour {

	public int minionsToSpawn;
	public int bossesToSpawn;
	public GameObject[] minions;
	public GameObject[] bosses;

	// Use this for initialization
	void Start () {
	
		for (int i = 0; i < minionsToSpawn; i++) {
			int rand = Random.Range(0,minions.Length);
			Vector3 randomIn = Random.insideUnitSphere * 1400;
			randomIn.z = -1;
			GameObject clone = (GameObject) Instantiate(minions[rand], randomIn, Quaternion.identity);
		}
			
		for (int i = 0; i < bossesToSpawn; i++) {
			int rand = Random.Range(0,bosses.Length);
			Vector3 randomIn = Random.insideUnitSphere * 1600;
			randomIn.z = -1;
			GameObject clone = (GameObject) Instantiate(bosses[rand], randomIn, Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
