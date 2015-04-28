using UnityEngine;
using System.Collections;

public class gameManager : MonoBehaviour {

	public GameObject charSaveObj;
	public GameObject worldSaveObj;
	bool inGame = false;
	public int selectedWorld = -1;
	public int selectedChar = -1;

	public string[] classes = {"Warrior", "Thief", "Wizard", "Bard"};
	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad (gameObject);
		DontDestroyOnLoad (charSaveObj);
		DontDestroyOnLoad (worldSaveObj);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnLevelWasLoaded(int level)
	{
		if(Application.loadedLevelName=="MainMenu")
		{
			selectedChar = -1;
			selectedWorld = -1;
		}
	}

	public void createCharacter(int selectedClass, string name)
	{
		usave_file charSave = charSaveObj.GetComponent<usave_file> ();
		/*
		 * Stats:
		 * 1. Vitality
		 * 2. Power
		 * 3. Attack Speed
		 * 4. Defense
		 * 5. Move Speed
		 */
		int[] stats = {selectedClass, 1, 0, 10, 10, 10, 10, 10};
		charSave.iarray = stats;
		charSave.sarray [0] = name;
		charSave.slot = selectedChar;
		charSave.saveFile ();
	}
}
