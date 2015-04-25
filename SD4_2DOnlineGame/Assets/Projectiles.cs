using UnityEngine;
using System.Collections;

public class Projectiles : MonoBehaviour {

	public Vector3 target;
	public float speed;
	float liveTime = 1.5f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		liveTime -= Time.deltaTime;
		if (liveTime <= 0)
			Destroy (gameObject);

		transform.position = Vector3.MoveTowards (transform.position, target, speed * Time.deltaTime);


	}
}
