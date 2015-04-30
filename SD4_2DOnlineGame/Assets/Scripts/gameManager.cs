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

		if (selectedClass == 0) {
			float[] stats = {selectedClass, 1f, 0f, 15f, 2f, 4f, 10f, 10f, 20f};
			charSave.iarray = stats;
			charSave.sarray [0] = name;
			charSave.slot = selectedChar;
			charSave.saveFile ();
		} else
		if (selectedClass == 1) {
			float[] stats = {selectedClass, 1f, 0f, 25f, 1f, 4f, 20f, 8f, 20f};
			charSave.iarray = stats;
			charSave.sarray [0] = name;
			charSave.slot = selectedChar;
			charSave.saveFile ();
		} else
			if (selectedClass == 2) {
			float[] stats = {selectedClass, 1f, 0f, 10f, 6f, 3f, 10f, 12f, 20f};
			charSave.iarray = stats;
			charSave.sarray [0] = name;
			charSave.slot = selectedChar;
			charSave.saveFile ();
		} else {
			float[] stats = {selectedClass, 1f, 0f, 15f, 8f, 10f, 10f, 15f, 20f};
			charSave.iarray = stats;
			charSave.sarray [0] = name;
			charSave.slot = selectedChar;
			charSave.saveFile ();
		}
		







	}
}
