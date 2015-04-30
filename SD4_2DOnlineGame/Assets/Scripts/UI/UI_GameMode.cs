using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_GameMode : MonoBehaviour {
	
	public Text [] statDisplay;
    public Image hpBarColor, expBarColor;
    public Text expBarTxt;

    public playercontroller playerInfo;
    /*
     * Important info:
     * iarray - array that holds character stats
     *          index 1 = level
     *          index 2 = experience?
     *          index 3 = vitality
     *          index 4 = power
     *          index 5 = atk speed
     *          index 6 = defense
     *          index 7 = move speed
     **/
    //usave_file charSave;

	void Awake () {
		//Get Text components if not already set
		if (statDisplay.Length == 0 && 
		    GetComponentsInChildren<Text>() != null)
			statDisplay = GetComponentsInChildren<Text>();

        //Get HP bar if not already set
        //if (hpBarColor == null &&
        //    this.transform.Find(transform.name + "/HP_Bar/HP_Bar_Color").GetComponent<Image>() != null)
        //    hpBarColor = this.transform.Find(transform.name + "/HP_Bar/HP_Bar_Color").GetComponent<Image>();

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
        hpBarColor.fillAmount = (float) playerInfo.currVitality / playerInfo.vitality;
        
        //Set experience bar to show accumulated exp for the current level
        expBarColor.fillAmount = playerInfo.currEXP / playerInfo.nextLevelEXP;
        expBarTxt.text = "LV" + playerInfo.level.ToString();

        //Setting text strings to display attack, defense and speed
        statDisplay[0].text = "PWR - " + playerInfo.power;
        statDisplay[1].text = "AtkDelay - " + playerInfo.atkSpd;
		statDisplay [2].text = "Health - " + playerInfo.currVitality + " : " + playerInfo.vitality;
        statDisplay[3].text = "SPD - " + playerInfo.moveSpd;
    }
}
