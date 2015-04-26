using UnityEngine;
using System.Collections;

public class playercontroller : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKey (KeyCode.W)) {
			transform.position += Vector3.up * Time.deltaTime;
		}

		if (Input.GetKey (KeyCode.S)) {
			transform.position += Vector3.down * Time.deltaTime;
		}

		if (Input.GetKey (KeyCode.D)) {
			transform.position += Vector3.right * Time.deltaTime;
		}

		if (Input.GetKey (KeyCode.A)) {
			transform.position += Vector3.left * Time.deltaTime;
		}

	}
}
