using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_GameMode : MonoBehaviour {
	
	public Text [] statDisplay;
    public Button hpBar;

    public playercontroller playerInfo;

	void Awake () {
		//Get Text components if not already set
		if (statDisplay == null && 
		    GetComponentsInChildren<Text>() != null)
			statDisplay = GetComponentsInChildren<Text>();

        //Get HP bar if not already set
        if (hpBar == null &&
            GetComponentsInChildren<Button>() != null)
            hpBar = GetComponentInChildren<Button>();

        //Gets playercontroller component on player GameObject
        if (playerInfo == null && 
            GameObject.FindGameObjectWithTag("Player").GetComponent<playercontroller>() != null)
            playerInfo = GameObject.FindGameObjectWithTag("Player").GetComponent<playercontroller>();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        updatePlayerStats();
	}

    void updatePlayerStats() {
        //Setting HP bar to show remaining HP
        hpBar.image.fillAmount = playerInfo.currHealth / playerInfo.health;

        //Setting text strings to display attack, defense and speed
        statDisplay[0].text = "ATK - ";
        statDisplay[1].text = "DEF - ";
        statDisplay[2].text = "SPD - ";
    }
}
