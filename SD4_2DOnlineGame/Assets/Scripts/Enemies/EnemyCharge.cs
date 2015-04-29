using UnityEngine;
using System.Collections;

public class EnemyCharge : MonoBehaviour {

	public EnemyStats enemyStats;

    EnemyAnimations ea;

	Vector3 target;
	bool charge;

	float speed;

    void Awake()
    {
        //Get the enemy animation control script 
        if (GetComponentInChildren<EnemyAnimations>() != null)
            ea = GetComponentInChildren<EnemyAnimations>();
    }
	
	// Use this for initialization
	void Start () {
		enemyStats = GetComponent<EnemyStats> ();
		speed = enemyStats.moveSpeed;
	}
	
	// Update is called once per frame
	void Update () {
        //Updates the animation informatino for this enemy
        updateAnimation();

		if (charge) {
			transform.position = Vector3.MoveTowards (transform.position, target, speed * Time.deltaTime);
			if (transform.position == target)
				charge = false;
		}
	}

    void updateAnimation()
    {
        //Tells enemy animaiton controller whether it is moving or not
        ea.setMoving(charge);

        //Tells enemy animation controller to change direction as needed
        if (ea.getDirection() == true && target.x < transform.position.x ||
            ea.getDirection() == false && target.x > transform.position.x)
            ea.updateSpriteDirection();
    }

	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "Player") {
			target = col.transform.position;
			charge = true;
		}
	}

	void OnTriggerStay2D (Collider2D col) {
		if (col.tag == "Player") {
			target = col.transform.position;
			charge = true;
		}
	}
}