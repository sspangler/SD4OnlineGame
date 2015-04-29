using UnityEngine;
using System.Collections;

public class TerrainControl : MonoBehaviour {
	
	//DECLARATIONS
	public Transform origin;			
	public Transform player;
	public int distanceFromOrigin;					
	public Material[] materials;
	public int [] z1 = new int [9];
	public int [] z2 = new int [9]; 
	public int [] z3 = new int [9];
	public int [] z4 = new int [9];
	public int [] tileTex = new int[25];
	public GameObject[] terrains;
	public Renderer [] rend;
	
	
	public float ydist = 0;
	public float xdist = 0;
	public int difficultyZone = 0;

	public int minionsToSpawn;
	public int bossesToSpawn;
	public GameObject[] minions;
	public GameObject[] bosses;

	bool spawned;
	
	
	void Start () 
	{	
		//terrains = GameObject.FindGameObjectsWithTag("Terrain");

		
		//INITIALIZE OBJECTS TO BE USED IN REFERENCE TO DISTANCE
		origin = GameObject.FindGameObjectWithTag("Origin").transform; 
		player = GameObject.FindGameObjectWithTag("Player").transform;

		for (int x = 0; x< 25; x++) {
			

			tileTex[x] = (int)Random.Range (0, 10);
			rend[x].material = materials [tileTex[x]];
		}






		ydist = Mathf.Abs( player.position.y - origin.transform.position.y);
		xdist = Mathf.Abs (player.position.x - origin.transform.position.x);
		
		
		//SET THE DIFFICULTY ZONE BASED UPON THIS DISTANCE (OTHER SCRIPTS WILL USE THE DIFFICULTY ZONE TO DETERMINE THE DIFFICULTY OF ENEMIES)
		if ((xdist >= 1100 && xdist < 1500) || (ydist >= 1100 && ydist < 1500))
		{
			
			difficultyZone = 4;
		}
		else if ((xdist >= 700 && xdist < 1100) || (ydist >= 700 && ydist < 1100) )
		{
			
			difficultyZone = 3;
		} 
		else if ((xdist >= 300 && xdist < 700) || (ydist >= 300 && ydist < 700) )
		{
			
			difficultyZone = 2;
		}
		else if (xdist < 300 || ydist < 300)
		{ 
			
			
			difficultyZone = 1;
		}
		
		
		
		
	






		
	}
	
	void Update ()
	{


//				for (int i = 0; i < minionsToSpawn; i++) {
//					int rand = Random.Range(0,minions.Length);
//					Vector3 randomIn = Random.insideUnitSphere * 100;
//					randomIn.z = -1;
//					GameObject clone = (GameObject) Instantiate(minions[rand], tempPosition + randomIn, Quaternion.identity);
//					clone.GetComponent<EnemyStats>().diffMod = difficultyZone;
//				}
//
//				for (int i = 0; i < bossesToSpawn; i++) {
//					int rand = Random.Range(0,bosses.Length);
//					Vector3 randomIn = Random.insideUnitSphere * 100;
//					randomIn.z = -1;
//					GameObject clone = (GameObject) Instantiate(bosses[rand], tempPosition + randomIn, Quaternion.identity);
//					clone.GetComponent<EnemyStats>().diffMod = difficultyZone;
//				}


			
			// CHECK THE DISTANCES OF THE MOVED TILES IN ORDER TO DETERMINE THE MATERIALS THAT SHOULD BE APPLIED
			
		Zone ();
	}

	void Zone ()
	{

		ydist = Mathf.Abs( player.position.y - origin.transform.position.y);
		xdist = Mathf.Abs (player.position.x - origin.transform.position.x);
		
		
		//SET THE DIFFICULTY ZONE BASED UPON THIS DISTANCE (OTHER SCRIPTS WILL USE THE DIFFICULTY ZONE TO DETERMINE THE DIFFICULTY OF ENEMIES)
		if ((xdist >= 1100 && xdist < 1500) || (ydist >= 1100 && ydist < 1500))
		{
			
			difficultyZone = 4;
		}
		else if ((xdist >= 700 && xdist < 1100) || (ydist >= 700 && ydist < 1100) )
		{
			
			difficultyZone = 3;
		} 
		else if ((xdist >= 300 && xdist < 700) || (ydist >= 300 && ydist < 700) )
		{
			
			difficultyZone = 2;
		}
		else if (xdist < 300 || ydist < 300)
		{ 
			
			
			difficultyZone = 1;
		}
		
		
		
		
	}
	
	
}