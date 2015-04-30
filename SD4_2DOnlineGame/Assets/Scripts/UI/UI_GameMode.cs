using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_GameMode : MonoBehaviour {
	
	public Text [] statDisplay;
    public Image hpBarColor, expBarColor;
    public Text hpBarTxt, expBarTxt;

    public playercontroller playerInfo;

	void Awake () {
		//Get Text components if not already set
		if (statDisplay.Length == 0 && 
		    GetComponentsInChildren<Text>() != null)
			statDisplay = GetComponentsInChildren<Text>();

        //Gets playercontroller component on player GameObject
        if (playerInfo == null &&
            GameObject.FindGameObjectWithTag("Player").GetComponent<playercontroller>() != null)
            playerInfo = GameObject.FindGameObjectWithTag("Player").GetComponent<playercontroller>();
	}

	// Use this for initialization
	void Start () {
        updatePlayerStats();
	}
	
	// Update is called once per frame
	void Update () {
        updatePlayerStats();
	}

    void updatePlayerStats() {
        //Setting HP bar to show remaining HP
        hpBarColor.fillAmount = (float) playerInfo.currVitality / playerInfo.vitality;
        hpBarTxt.text = "HP " + playerInfo.currVitality + "/" + playerInfo.vitality;
        
        //Set experience bar to show accumulated exp for the current level
        expBarColor.fillAmount = (float) playerInfo.currEXP / playerInfo.nextLevelEXP;
        expBarTxt.text = "LV" + playerInfo.level.ToString();

        //Setting text strings to display attack, defense and speed
        statDisplay[0].text = "PWR - " + playerInfo.power.ToString();
        statDisplay[1].text = "AtkDelay - " + playerInfo.atkSpd.ToString();
		//statDisplay [2].text = "Health - " + playerInfo.currVitality + " : " + playerInfo.vitality;
        statDisplay[2].text = "DEF - " + playerInfo.def.ToString();
        statDisplay[3].text = "SPD - " + playerInfo.moveSpd.ToString();
    }
}
