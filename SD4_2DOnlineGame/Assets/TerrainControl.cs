using UnityEngine;
using System.Collections;

public class TerrainControl : MonoBehaviour {
	
	//DECLARATIONS
	public Transform origin;			
	public Transform player;
	public int distanceFromOrigin = 0;					
	public Material[] materials = new Material[4];
	public int [] z1 = new int [9];
	public int [] z2 = new int [9]; 
	public int [] z3 = new int [9];
	public int [] z4 = new int [9];
	public GameObject[] terrains = GameObject.FindGameObjectsWithTag("Terrain");
	public Renderer [] rend = new Renderer[9];
	
	
	public float zdist = 0;
	public float xdist = 0;
	public int difficultyZone = 0;
	
	
	
	void Start () 
	{	for (int x = 0; x< 9; x++) {
			
			//INITIALIZE TILES
			rend [x] = terrains [x].GetComponent<Renderer> ();
			z1 [x] = (int)Random.Range (0f, 3f); 
			z2 [x] = (int)Random.Range (4f, 5f);
			z3 [x] = (int)Random.Range (6f, 7f);
			z4 [x] = (int)Random.Range (8f, 9f);
			rend[x].material = materials [z1[x]]; //SET INITIAL MATERIALS TO ZONE 1
		}
		
		
		//INITIALIZE OBJECTS TO BE USED IN REFERENCE TO DISTANCE
		origin = GameObject.FindGameObjectWithTag("Origin").transform; 
		player = GameObject.FindGameObjectWithTag("Player").transform;
		
	}
	
	void Update ()
	{
		for (int x = 0; x<9; x++) {
			
			Vector3 tempPosition = terrains[x].transform.position;
			//CHECKS THE X AND Z POSITIONS TO SEE IF THE TILE NEEDS TO MOVE (USED TO CREATE PSEUDO-INFINITE TERRAIN	
			
			if (player.transform.position.x - tempPosition.x >= 300) {
				
				tempPosition.x += 600;
				terrains[x].transform.position = tempPosition;
				
			}
			
			if (player.transform.position.x - tempPosition.x < -300) {
				tempPosition.x -=600;
				terrains[x].transform.position = tempPosition;
			}
			
			
			if (player.transform.position.z -tempPosition.z >= 300) {
				
				tempPosition.z += 600;
				
				terrains[x].transform.position = tempPosition;
				
			}
			
			if (player.transform.position.z - tempPosition.z < -300) {
				tempPosition.z -=600;
				terrains[x].transform.position = tempPosition;
				
			}
			
			
			// CHECK THE DISTANCES OF THE MOVED TILES IN ORDER TO DETERMINE THE MATERIALS THAT SHOULD BE APPLIED
			if (Mathf.Abs (terrains[x].transform.position.x - origin.position.x) >= 1600 || Mathf.Abs (terrains[x].transform.position.z - origin.position.z) >= 1600) {
				rend[x].material = materials [z4[x]]; 
				
			} else if ((Mathf.Abs (terrains[x].transform.position.x - origin.position.x) >= 1200 && Mathf.Abs (terrains[x].transform.position.x - origin.position.x) < 1600) || (Mathf.Abs (terrains[x].transform.position.z - origin.position.z) >= 1200 && Mathf.Abs (terrains[x].transform.position.z - origin.position.z) < 1600)) {
				//rend.material.color = Color.black;
				rend[x].material = materials [z4[x]]; 
			} else if ((Mathf.Abs (terrains[x].transform.position.x - origin.position.x) >= 800 && Mathf.Abs (terrains[x].transform.position.x - origin.position.x) < 1200) || (Mathf.Abs (terrains[x].transform.position.z - origin.position.z) >= 800 && Mathf.Abs (terrains[x].transform.position.z - origin.position.z) < 1200)) {
				//rend.material.color = Color.red;
				rend[x].material = materials [z3[x]]; 	
			} else if ((Mathf.Abs (terrains[x].transform.position.x - origin.position.x) >= 400 && Mathf.Abs (terrains[x].transform.position.x - origin.position.x) < 800) || (Mathf.Abs (terrains[x].transform.position.z - origin.position.z) >= 400 && Mathf.Abs (terrains[x].transform.position.z - origin.position.z) < 800)) {
				//rend.material.color = Color.blue;
				rend[x].material = materials [z2[x]]; 
				
			} else if (Mathf.Abs (terrains[x].transform.position.x - origin.position.x) < 400 || Mathf.Abs (terrains[x].transform.position.z - origin.position.z) < 400) { 
				
				//rend.material.color = Color.green;
				rend[x].material = materials [z1[x]]; 
				
			}
			
			
			
		}
		
		Zone ();
	}
	
	void Zone ()
	{
		
		
		zdist = Mathf.Abs( player.position.z - origin.transform.position.z);
		xdist = Mathf.Abs (player.position.x - origin.transform.position.x);
		
		
		//SET THE DIFFICULTY ZONE BASED UPON THIS DISTANCE (OTHER SCRIPTS WILL USE THE DIFFICULTY ZONE TO DETERMINE THE DIFFICULTY OF ENEMIES)
		if ((xdist >= 1100 && xdist < 1500) || (zdist >= 1100 && zdist < 1500))
		{
			
			difficultyZone = 4;
		}
		else if ((xdist >= 700 && xdist < 1100) || (zdist >= 700 && zdist < 1100) )
		{
			
			difficultyZone = 3;
		} 
		else if ((xdist >= 300 && xdist < 700) || (zdist >= 300 && zdist < 700) )
		{
			
			difficultyZone = 2;
		}
		else if (xdist < 300 || zdist < 300)
		{ 
			
			
			difficultyZone = 1;
		}
		
		
		
		
	}
	
	
}