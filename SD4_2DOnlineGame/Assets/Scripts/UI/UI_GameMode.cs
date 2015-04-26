using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_GameMode : MonoBehaviour {

	public Text [] statDisplay;

	void Awake () {
		//Get Text components if not already set
		if (statDisplay == null && 
		    GetComponentsInChildren<Text>() != null)
			statDisplay = GetComponentsInChildren<Text>();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
