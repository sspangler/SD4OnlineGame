#pragma strict
public var origin: Transform;
public var player: Transform;
public var distanceFromOrigin = 0;
var rend = GetComponent.<Renderer>();

function Start () 
{


	origin = GameObject.FindGameObjectWithTag("Origin").transform;
	player = GameObject.FindGameObjectWithTag("Player").transform;
	
}

function Update ()
{
 /*if (player.transform.position.x - Transform.position.x = 25)
	{
	}
	else if (player.transform.position.x - transform.position.x = -25)
	{
	}
	else if (player.transform.position.z -transform.position.z = 25)
	{
	}
	else if (player.transform.position.z - transform.position.z = -25) 
	{
	}

	distanceFromOrigin = Vector3.Distance(origin.position,this.transform.position);

 	if (distanceFromOrigin < 100)
 	{ 
 		rend.material.color = Color.green;
		
 		
	}
	 else if (distanceFromOrigin >= 100 && distanceFromOrigin < 200)
	 {
	 	rend.material.color = Color.blue;
	 	
	 }
	 else if (distanceFromOrigin >= 200 && distanceFromOrigin < 300)
	 {
	 	rend.material.color = Color.red;
	 	
	 }
	 else if (distanceFromOrigin >= 300 && distanceFromOrigin < 400)
	 {
	 	rend.material.color = Color.black;
	 	
	 
	 }
	 */

}