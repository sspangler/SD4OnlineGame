using UnityEngine;
using System.Collections;

public class playercontroller : MonoBehaviour {

    public int level, currEXP, nextLevelEXP;
    public int currVitality, vitality;
    public float healthRegen;
    public int power, atkSpd, def, moveSpd;
	public float tempTime;
	
	public GameObject bullet;

    public bool isMoving;

	public float IFrames;

    /*
     * Important info:
     * iarray - array that holds character stats
     *          index 1 = level
     *          index 2 = experience?
     *          index 3 = vitality
     *          index 4 = power
     *          index 5 = atk speed
     *          index 6 = defense
     *          index 7 = move speed
     **/
    usave_file charSave;

    void Awake() {
        //Get character save information
        if (GameObject.Find("CharSave").GetComponent<usave_file>() != null) {
            charSave = GameObject.Find("CharSave").GetComponent<usave_file>();
        }
    }

	// Use this for initialization
	void Start () {

		IFrames = .5f;

	    //Read character stats from save file
        level = charSave.iarray[1];
        currEXP = charSave.iarray[2];
        nextLevelEXP = (int)Mathf.Pow(level, 2f);    //Change to represent experience needed for current level
        vitality = charSave.iarray[3];
        currVitality = vitality;
		power = charSave.iarray[4];
        atkSpd = charSave.iarray[5];
        def = charSave.iarray[6];
        moveSpd = charSave.iarray[7];
	}
	
	// Update is called once per frame
	void Update () {
        MovePlayer();
        ValueCorrection();

		if (IFrames >= 0)
			IFrames -= Time.deltaTime;
		
		tempTime += Time.deltaTime;
		
		if (tempTime >= atkSpd)
		{
			if (Input.GetMouseButton (0)) 	
			{
				GameObject clone = (GameObject) Instantiate (bullet, transform.position, Quaternion.identity);
				
				tempTime = 0;
			}
		}
	}

    void MovePlayer()
    {
        //Read horizontal input (-1 for left, 1 for right, 0 for none)
        float horizontal = Input.GetAxis("Horizontal");

        ///Read vertical input (-1 for down, 1 for up, 0 for none)
        float vertical = Input.GetAxis("Vertical");

        //If either horizontal or vertical movement is detected,
        //then the player is moving.
        //Otherwise, reset moving status
        if (horizontal != 0f || vertical != 0f)
            isMoving = true;
        else if (horizontal == 0f && vertical == 0f)
            isMoving = false;

        //Move player transform an amount equal to moveSpeed in respective directions
        transform.position += new Vector3(horizontal * (moveSpd / 1) * Time.deltaTime,
                                          vertical * (moveSpd / 1) * Time.deltaTime,
                                          0);
    }

    void ValueCorrection() {
        Mathf.Clamp(currVitality, 0, vitality);
        Mathf.Clamp(currEXP, 0, nextLevelEXP);
    }

    void LevelUp() {
        if (currEXP >= nextLevelEXP) {
            //Get experience needed for current level
            float prevLevelEXP = Mathf.Pow(level, 2f);

            //Add any leftover experience after level up to current experience
            if (currEXP > nextLevelEXP)
                currEXP = (int) prevLevelEXP - currEXP;

            //Increment level and find new amount of experience needed to level up
            level++;
            nextLevelEXP = (int) Mathf.Pow(level, 2f);
        }
    }



	void OnCollisionEnter2D (Collision2D col) {
		print (col.gameObject.name);
		if (col.gameObject.tag == "Enemy") {
			if (IFrames<= 0) {
				currVitality -= (int)col.gameObject.GetComponent<EnemyStats>().Attack;
				if (currVitality <= 0) {
					Application.LoadLevel("Spash");			
				}
				Destroy(col.gameObject);
				IFrames = .5f;
			}

		} else if (col.gameObject.tag == "Enemybullet") {
			if (IFrames <= 0) {
				currVitality -= (int)col.gameObject.GetComponent<Projectiles>().power;
				if (currVitality <= 0)
				{
					Application.LoadLevel("Spash");
				}
				Destroy(col.gameObject);
				IFrames = .5f;
			}
		}
	}

}
