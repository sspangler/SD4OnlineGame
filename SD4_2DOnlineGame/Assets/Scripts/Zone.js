#pragma strict
//DECLARATIONS
public var player: Transform;
public var zdist = 0;
public var xdist = 0;
public var difficultyZone = 0;
;

function Start () 
{	//INITIALIZE HOW FAR PLAYER IS FROM ORIGIN
	zdist = 0;
	xdist = 0;

	//INITIALIZE A VARIABLE THAT IS SET TO THE TRANSFORM OF THE PLAYER
	player = GameObject.FindGameObjectWithTag("Player").transform;
	
}

function Update ()
{
	
	//CALCULATE THE DISTANCE IN BOTH THE X AND Y THAT THE PLAYER IS FROM THE ORIGIN
	zdist = Mathf.Abs( player.position.z - transform.position.z);
	xdist = Mathf.Abs (player.position.x - transform.position.x);
	
	
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