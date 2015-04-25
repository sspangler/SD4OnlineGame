#pragma strict
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

	z1 =  Random.Range(0f,3f);
	z2 =  Random.Range(4f,5f);
	z3 =  Random.Range(6f,7f);
	z4 =  Random.Range(8f,9f);
	rend.material = materials[z1]; 

	origin = GameObject.FindGameObjectWithTag("Origin").transform;
	player = GameObject.FindGameObjectWithTag("Player").transform;
	
}

function Update ()
{
 
 	
	if (player.transform.position.x - transform.position.x >= 75)
	{
		
		transform.position.x = (transform.position.x + 150);
		
		
	}
	
	if (player.transform.position.x - transform.position.x < -75)
	{
		transform.position.x = (transform.position.x - 150);
		
	}
	

 	 if (player.transform.position.z -transform.position.z >= 75)
	{
		
		transform.position.z = (transform.position.z + 150);
		
	}

 	 if (player.transform.position.z - transform.position.z < -75) 
	{
		transform.position.z = (transform.position.z - 150);
		
	}
	
	




	distanceFromOrigin = Vector3.Distance(origin.position,this.transform.position);

 	if (distanceFromOrigin < 100)
 	{ 
 		
 		//rend.material.color = Color.green;
 		rend.material = materials[z1]; 
		
 		
	}
	 else if (distanceFromOrigin >= 100 && distanceFromOrigin < 200)
	 {
	 	//rend.material.color = Color.blue;
	 	rend.material = materials[z2]; 
	 	
	 }
	 else if (distanceFromOrigin >= 200 && distanceFromOrigin < 300)
	 {
	 	//rend.material.color = Color.red;
	 	rend.material = materials[z3]; 
	
	 	
	 }
	 else if (distanceFromOrigin >= 300 && distanceFromOrigin < 400)
	 {
	 	//rend.material.color = Color.black;
	 	rend.material = materials[z4]; 
	 
	 	
	 
	 }
	 else if (distanceFromOrigin >= 400)
	 {
	 	rend.material = materials[z4]; 
	 
	 }
	 

}