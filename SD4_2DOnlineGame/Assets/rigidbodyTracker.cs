using UnityEngine;
using System.Collections;

public class rigidbodyTracker : MonoBehaviour {

	float timed;
	float time;
	float theirtime;
	public bool debugging = false;
	public bool debugging2 = false;
	public int priority = 4;
	int prioritytimer = 0;
	// Use this for initialization
	void Awake () {
		Debug.Log (GetComponent<NetworkView>().group);
	}
	
	// Update is called once per frame
	void Update () {
		prioritytimer += 1;
		time = (float) Network.time;
		//Network.RemoveRPCs (GetComponent<NetworkView> ().viewID);
		if(Network.isServer && prioritytimer >= priority)
		{
			GetComponent<NetworkView>().RPC("updateStuff", RPCMode.Others, transform.position, GetComponent<Rigidbody>().velocity);
			time = (float) Network.time;
			prioritytimer = 0;
		}
	}

	[RPC]
	void updateStuff(Vector3 pos, Vector3 rbvel)
	{
		transform.position = pos;
		GetComponent<Rigidbody>().velocity = rbvel;
		GetComponent<NetworkView>().RPC ("sendBack", RPCMode.Server, time);
	}

	[RPC]
	void sendBack(float newtheirtime)
	{
		theirtime = newtheirtime;
		logtime ();
	}

	void logtime()
	{
		if(debugging && Network.isServer)
		{
			Debug.Log("/*" + time);
			Debug.Log(theirtime);
			Debug.Log(Network.time + "*/");
		}
		else if(debugging2 && Network.isServer)
		{
			float a = (float) Network.time - time;
			Debug.Log (a);
		}
	}
}
