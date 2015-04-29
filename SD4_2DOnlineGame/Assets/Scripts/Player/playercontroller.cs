using UnityEngine;
using System.Collections;

public class playercontroller : MonoBehaviour {

    public float health, currHealth;
    public float healthRegen;
    public float moveSpeed;
    public float Attack;
    public float attackSpeed;
    public float defense;

    public bool isMoving, isAttacking;
	public GameObject bullet;
	public float tempTime;

	// Use this for initialization
	void Start () {

	

	
	}
	
	// Update is called once per frame
	void Update () {
        MovePlayer();

		tempTime += Time.deltaTime;

		if (tempTime >= attackSpeed)
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

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizontal != 0f || vertical != 0f)
            isMoving = true;
        else if (horizontal == 0f && vertical == 0f)
            isMoving = false;

        transform.position += new Vector3(horizontal * moveSpeed * Time.deltaTime,
                                          vertical * moveSpeed * Time.deltaTime,
                                          0);
    }

    //void ActivateAttack() {
    //    bool atk = Input.GetMouseButtonDown(0);

    //    if (!isAttacking && atk) isAttacking = true;
    //}

    //public void endAttack() {
    //    isAttacking = false;
    //}
}
