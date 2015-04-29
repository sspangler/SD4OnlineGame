using UnityEngine;
using System.Collections;

public class playercontroller : MonoBehaviour {

    public float level, currEXP, nextLevelEXP;
    public float currVitality, vitality, healthRegen;
    public float power, atkSpd, def, moveSpd;
	public float tempTime;
	
	public GameObject bullet;

    public bool isMoving;

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
	    //Read character stats from save file
        level = charSave.iarray[1];
        currEXP = charSave.iarray[2];
        nextLevelEXP = Mathf.Pow(level, 2f);    //Change to represent experience needed for current level
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
        //if (Input.GetKey(KeyCode.W))
        //{
        //    transform.position += Vector3.up * moveSpeed * Time.deltaTime;
        //    isMoving = true;
        //}

        //if (Input.GetKey(KeyCode.S))
        //{
        //    transform.position += Vector3.down * moveSpeed * Time.deltaTime;
        //    isMoving = true;
        //}

        //if (Input.GetKey(KeyCode.D))
        //{
        //    transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        //    isMoving = true;
        //}

        //if (Input.GetKey(KeyCode.A))
        //{
        //    transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        //    isMoving = true;
        //}

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
}
