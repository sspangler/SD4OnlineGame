using UnityEngine;
using System.Collections;

public class TerrainControl : MonoBehaviour {
	
	//DECLARATIONS
						
	public Material[] materials;
	public int [] tileTex = new int[25];
	public GameObject[] terrains;
	public Renderer [] rend;


	bool spawned;
	
	
	void Start () 
	{	
		terrains = GameObject.FindGameObjectsWithTag("Terrain");


		for (int x = 0; x< 25; x++) {
			

			tileTex[x] = (int)Random.Range (0, 10);
			rend[x].material = materials [tileTex[x]];
		}




		
	}
	
	void Update ()
	{


	}


	
}