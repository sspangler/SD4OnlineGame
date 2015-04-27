using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_GameMode : MonoBehaviour {
	
	public Text [] statDisplay;
    public Button hpBar;

	void Awake () {
		//Get Text components if not already set
		if (statDisplay == null && 
		    GetComponentsInChildren<Text>() != null)
			statDisplay = GetComponentsInChildren<Text>();

        //Get HP bar if not already set
        if (hpBar == null &&
            GetComponentsInChildren<Button>() != null)
            hpBar = GetComponentInChildren<Button>();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

    void displayPlayerStats() {

    }
}
