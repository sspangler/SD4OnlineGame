using UnityEngine;
using System.Collections;

public class playercontroller : MonoBehaviour {

    
	public float tempTime;
    public GameObject bullet;
    public float IFrames;

    //-----------------------------------------------------------------------------------
    public int classType;
    public int level, currEXP, nextLevelEXP;
    public int currVitality, vitality;
    public float healthRegen, atkSpd;
    public int power, def, moveSpd;

    /*
    * Important info:
    * modifyPercent - array that holds character growth rates
    *          index 0 = vitality
    *          index 1 = power
    *          index 2 = atk speed
    *          index 3 = defense
    *          index 4 = move speed
    **/
    float[] modifyPercent;
    bool growthRatesSet;
	
    SpriteRenderer sprRend;

    public bool isMoving;

    /*
     * Important info:
     * iarray - array that holds character stats
     *          index 0 = class type (0 - warrior, 1 - thief, 2 - wizard, 3 - bard)
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

        if (GetComponent<SpriteRenderer>() != null)
            sprRend = GetComponent<SpriteRenderer>();
    }

	// Use this for initialization
	void Start () {

		IFrames = .5f;

	    //Read character stats from save file
        if (charSave != null) {
            classType = (int)charSave.iarray[0];
            level = (int)charSave.iarray[1];
            currEXP = (int)charSave.iarray[2];
            nextLevelEXP = (int)Mathf.Pow(level, 2f);    //Change to represent experience needed for current level
            vitality = (int)charSave.iarray[3];
            currVitality = (int)vitality;
            power = (int)charSave.iarray[4];
            atkSpd = charSave.iarray[5] * 0.1f;
            def = (int)charSave.iarray[6];
            moveSpd = (int)charSave.iarray[7];
        }

        //Initializes growth rates array and calculates apprpriate values based on class
        modifyPercent = new float[5];
        if (!growthRatesSet)
            SetGrowthRates();

        //Set color based on class
        if (sprRend != null) {
            switch (classType) {
                //Warrior
                case 0:
                    sprRend.color = Color.yellow;
                    break;
                //Thief
                case 1:
                    sprRend.color = Color.gray;
                    break;
                //Wizard
                case 2:
                    sprRend.color = Color.magenta;
                    break;
                //Bard
                case 3:
                    sprRend.color = Color.green;
                    break;
                default: break;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        MovePlayer();
        ValueCorrection();
		if (currVitality<=0)
		{
			charSave.deleteFile();
			Application.LoadLevel("MainMenu");
		}

        //if the player presses Escape,
        //then save the player's current stats and return to main menu
		if (Input.GetKeyDown (KeyCode.Escape)) {
            SavePlayerInfo();

            //return to main menu
			Application.LoadLevel("MainMenu");
		}

		if (IFrames >= 0)
			IFrames -= Time.deltaTime;
		
		tempTime += Time.deltaTime;
		
		if (tempTime >= atkSpd) {
			if (Input.GetMouseButton (0)) {
				Instantiate (bullet, transform.position, Quaternion.identity);	
				tempTime = 0;
			}
		}
	}

    void MovePlayer() {
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
        transform.position += new Vector3 (horizontal * (moveSpd / 1.5f) * Time.deltaTime,
                                          vertical * (moveSpd / 1.5f) * Time.deltaTime,
                                          0);
    }

    void ValueCorrection() {
        //Keeps current vitality within range of actual vitality
        Mathf.Clamp(currVitality, 0, vitality);

        //keeps current experience gained within range of amount needed for current level
        Mathf.Clamp(currEXP, 0, nextLevelEXP);
    }

    public void LevelUp() {
        if (currEXP >= nextLevelEXP) {
            //Get experience needed for current level
            int prevLevelEXP = (int) Mathf.Pow(level, 2f);

            //Increment level and find new amount of experience needed to level up
            level++;
            nextLevelEXP = (int)Mathf.Pow(level, 2f);

            //Add any leftover experience after level up to current experience
            //if (currEXP > nextLevelEXP)
            int v = currEXP - prevLevelEXP;
            currEXP = v;
            Mathf.Clamp(currEXP, 0, nextLevelEXP);

            //Modify stats based on class
            //Check for the probability of increasing a stat for each class
            for (int i = 0; i < modifyPercent.Length; i++) {
                //Generate float from range 0 to 1
                float c = Random.Range(0f, 1f);

                //If generated value falls within growth percent range,
                //increase the appropriate stat
                if (c <= modifyPercent[i]) {
                    switch (i) {
                        //Vitality increase
                        case 0:
                            vitality += 3;
                            currVitality = vitality;
                            break;
                        //Power increase
                        case 1:
                            power += 1;
                            break;
                        //Attack speed increase
                        case 2:
                            //Bring attackspeed to non-decimal value
                            atkSpd *= 10;

                            //Increment attack speed, keeping it within range
                            if (atkSpd > 2)
                                atkSpd -= 1;
                            Mathf.Clamp(atkSpd, 2, 8);

                            //Return to decimal value
                            atkSpd *= 0.1f;
                            break;
                        //Defense increase
                        case 3:
                            def += 1;
                            break;
                        //move speed increase
                        case 4:
                            moveSpd += 1;
                            break;
                    }
                }
            }

            //Save stats after level up
            SavePlayerInfo();
		}	
    }

    void SavePlayerInfo()
    {
        //get current stats and place them into an array
        float[] stats = {classType, level, currEXP, vitality, power, atkSpd * 10, def, moveSpd };

        //pass values into character save file
        charSave.iarray = stats;

        //run the save to file method
        charSave.saveFile();
    }

    void SetGrowthRates() {
        if (!growthRatesSet) {
            //Initialize growth rates
            for (int i = 0; i < modifyPercent.Length; i++) {
                modifyPercent[i] = 0.5f;
            }

            //Modify growth rates based on class
            /*
            * Important info:
            * modifyPercent - array that holds character growth rates
            *          index 0 = vitality
            *          index 1 = power
            *          index 2 = atk speed
            *          index 3 = defense
            *          index 4 = move speed
            **/
            switch (classType) {
                //Warrior
                case 0:
                    modifyPercent[0] += 0.35f;
                    modifyPercent[1] += 0.25f;
                    modifyPercent[2] -= 0.3f;
                    modifyPercent[3] -= 0.1f;
                    modifyPercent[4] -= 0.4f;
                    break;
                //Thief
                case 1:
                    modifyPercent[0] -= 0.3f;
                    modifyPercent[1] -= 0.25f;
                    modifyPercent[2] += 0.15f;
                    modifyPercent[3] -= 0.45f;
                    modifyPercent[4] += 0.4f;
                    break;
                //Wizard
                case 2:
                    modifyPercent[0] -= 0.25f;
                    modifyPercent[1] += 0.4f;
                    modifyPercent[2] -= 0.15f;
                    modifyPercent[3] -= 0.35f;
                    modifyPercent[4] -= 0.2f;
                    break;
                //Bard
                case 3:
                    modifyPercent[0] += 0.1f;
                    modifyPercent[1] -= 0.1f;
                    modifyPercent[2] += 0.1f;
                    modifyPercent[3] -= 0.25f;
                    modifyPercent[4] += 0.1f;
                    break;
                default: break;
            }

            //Prevent growth rates from being altered by this method again
            growthRatesSet = true;
        }
    }
    

	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == "Enemy") {
			if (IFrames<= 0) {
                int dmg = (int)col.gameObject.GetComponent<EnemyStats>().Attack - def;
                if (dmg < 1) dmg = 1;
                currVitality -= dmg;
				if (currVitality <= 0) {
					Application.LoadLevel("Splash");		
				}
				//Destroy(col.gameObject);
				IFrames = .5f;
			}

		} else if (col.gameObject.tag == "EnemyBullet") {
			if (IFrames <= 0) {
                int dmg = (int)col.gameObject.GetComponent<Projectiles>().power - def;
                if (dmg < 1) dmg = 1;
                currVitality -= dmg;
				if (currVitality <= 0)
				{
					Application.LoadLevel("Splash");
				}
				Destroy(col.gameObject);
				IFrames = .5f;
			}
		}
	}
}
