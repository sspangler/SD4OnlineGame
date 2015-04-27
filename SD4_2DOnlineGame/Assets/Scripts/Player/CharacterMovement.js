#pragma strict


var moveSpeed = 8;

function Start () {


}

function Update () {
if (Input.GetKey(KeyCode.A)) {
			transform.position += Vector3.left * moveSpeed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.D)) {
			transform.position += Vector3.right * moveSpeed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.W)) {
			transform.position += Vector3.up * moveSpeed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.S)) {
			transform.position += Vector3.down * moveSpeed * Time.deltaTime;
		}

}
