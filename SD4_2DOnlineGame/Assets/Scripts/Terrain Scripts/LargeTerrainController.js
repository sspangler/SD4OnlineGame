#pragma strict
//DECLARATIONS
public var origin: Transform;				
public var player: Transform;
public var distanceFromOrigin = 0;					
var rend = GetComponent.<Renderer>();
public var materials: Material[];
public var z1;
public var z2; 
public var z3;
public var z4;



function Start () 
{
	//INITIALIZE TILES
	z1 =  Random.Range(0f,3f); 
	z2 =  Random.Range(4f,5f);
	z3 =  Random.Range(6f,7f);
	z4 =  Random.Range(8f,9f);
	rend.material = materials[z1]; //SET INITIAL MATERIALS TO ZONE 1
	
	
	
	//INITIALIZE OBJECTS TO BE USED IN REFERENCE TO DISTANCE
	origin = GameObject.FindGameObjectWithTag("Origin").transform; 
	player = GameObject.FindGameObjectWithTag("Player").transform;
	
}

function Update ()
{
 	//CHECKS THE X AND Z POSITIONS TO SEE IF THE TILE NEEDS TO MOVE (USED TO CREATE PSEUDO-INFINITE TERRAIN	
 	
	if (player.transform.position.x - transform.position.x >= 300)
	{
		
		transform.position.x = (transform.position.x + 600);
		
		
	}
	
	if (player.transform.position.x - transform.position.x < -300)
	{
		transform.position.x = (transform.position.x - 600);
		
	}
	

 	 if (player.transform.position.z -transform.position.z >= 300)
	{
		
		transform.position.z = (transform.position.z + 600);
		
	}

 	 if (player.transform.position.z - transform.position.z < -300) 
	{
		transform.position.z = (transform.position.z - 600);
		
	}
	
	
// CHECK THE DISTANCES OF THE MOVED TILES IN ORDER TO DETERMINE THE MATERIALS THAT SHOULD BE APPLIED
 	if (Mathf.Abs( transform.position.x - origin.position.x ) >= 1600 || Mathf.Abs( transform.position.z - origin.position.z )>= 1600   )
	 {
	 	rend.material = materials[z4]; 
	 
	 }

	 else if ((Mathf.Abs( transform.position.x - origin.position.x ) >= 1200 && Mathf.Abs( transform.position.x - origin.position.x ) < 1600) || (Mathf.Abs( transform.position.z - origin.position.z ) >= 1200 && Mathf.Abs( transform.position.z - origin.position.z ) < 1600) )
	 {
	 	//rend.material.color = Color.black;
	 	rend.material = materials[z4]; 
	 }
	 
	 else if ((Mathf.Abs( transform.position.x - origin.position.x ) >= 800 && Mathf.Abs( transform.position.x - origin.position.x ) < 1200) || (Mathf.Abs( transform.position.z - origin.position.z ) >= 800 && Mathf.Abs( transform.position.z - origin.position.z ) < 1200) )
	 {
	 	//rend.material.color = Color.red;
	 	rend.material = materials[z3]; 	
	 }
	 
	else if ((Mathf.Abs( transform.position.x - origin.position.x ) >= 400 && Mathf.Abs( transform.position.x - origin.position.x ) < 800) || (Mathf.Abs( transform.position.z - origin.position.z ) >= 400 && Mathf.Abs( transform.position.z - origin.position.z ) < 800) )
	 {
	 	//rend.material.color = Color.blue;
	 	rend.material = materials[z2]; 
	 	
	 }
	
	else if (Mathf.Abs( transform.position.x - origin.position.x )< 400 || Mathf.Abs( transform.position.z - origin.position.z )< 400   )
 	{ 
 		
 		//rend.material.color = Color.green;
 		rend.material = materials[z1]; 
		
	}




	


}