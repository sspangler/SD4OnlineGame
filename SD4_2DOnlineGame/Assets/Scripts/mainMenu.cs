using UnityEngine;
using System.Collections;

public class mainMenu : MonoBehaviour {

	gameManager gameManagerRef;
	public string[] storedNames;
	usave_file charSave;
	// Use this for initialization
	void Awake () {
		gameManagerRef = GameObject.Find ("GameManager").GetComponent < gameManager> ();
		storedNames = new string[10];
		for(int x=0;x<storedNames.Length;x++)
			storedNames[x] = "";
		charSave = gameManagerRef.charSaveObj.GetComponent<usave_file>();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnLevelWasLoaded(int level)
	{
		usave_file charSave = gameManagerRef.charSaveObj.GetComponent<usave_file>();
		bool filledSlot;
		for(int x=0;x<storedNames.Length;x++)
		{
			filledSlot = gameManagerRef.charSaveObj.GetComponent<usave_file>().ifSlot(x+1);
			if(filledSlot) {
				charSave.slot = x+1;
				charSave.loadFile();
				storedNames[x] = charSave.sarray[0];
			}
			else storedNames[x] = "";
		}
	}

	void OnGUI()
	{
		Rect[] charRects = rectGroup(10, 10, 10, 35, 90, 6);
		Rect[] worldRects = rectGroup(10, 40, 10, 65, 90, 6);
		int buttonID;
		string buttonString;
		bool filledSlot;
		// Character select
		for(int x=0;x<10;x++)
		{
			buttonID = x+1;
			filledSlot = gameManagerRef.charSaveObj.GetComponent<usave_file>().ifSlot(buttonID);
			if(filledSlot)
				buttonString = storedNames[x];
			else buttonString = "(" + buttonID.ToString() + ") New Hero";
			if (GUI.Button(charRects[x], buttonString))
			{
				gameManagerRef.selectedChar = buttonID;
				if(!filledSlot)
					Application.LoadLevel("CharacterCreation");
				else
				{
					charSave.slot = buttonID;
					charSave.loadFile();
				}
			}
		}
		GUI.Label(x100Rect(40f, 3f, 40f, 7f), "Start Server:");
		for(int x=0;x<10;x++)
		{
			buttonID = x+1;
			filledSlot = gameManagerRef.worldSaveObj.GetComponent<usave_file>().ifSlot(buttonID);
			if(filledSlot)
				buttonString = "World " + buttonID.ToString();
			else buttonString = "(" + buttonID.ToString() + ") New World";
			if (GUI.Button(worldRects[x], buttonString))
			{
				gameManagerRef.selectedWorld = buttonID;
				//if(!filledSlot)
				// Create world
			}
		}
		if(gameManagerRef.selectedChar!=-1 && Application.loadedLevelName=="MainMenu")
		{
			// Draw "Selected Character area
			Rect[] statRects = rectGroup(7, 70, 10, 100, 60, 5);
			/*string[] statStrings = {storedNames[gameManagerRef.selectedChar-1],
				"Lvl" + charSave.iarray[1].ToString() + " " + gameManagerRef.classes[charSave.iarray[0]],
				"Vitality: " + charSave.iarray[3].ToString(), 
				"Power: " + charSave.iarray[4].ToString(), 
				"Attack Speed: " + charSave.iarray[5].ToString(), 
				"Defense: " + charSave.iarray[6].ToString(), 
				"Speed: " + charSave.iarray[7].ToString()};
			for(int x=0;x<statStrings.Length;x++)
			{
				GUI.Label(statRects[x], statStrings[x]);
			}
			*/
			if(GUI.Button(x100Rect(70f, 70f, 30f, 10f), "Find Server"))
				Application.LoadLevel ("ServerSearch");

			if(GUI.Button(x100Rect(70f, 80f, 30f, 10f), "Start Solo"))
				Application.LoadLevel ("LargerTerrainTest");
		}
	}

	public Rect x100Rect (float x, float y, float sizex, float sizey, int pixelSpacer=0)
	{
		return x100Rect((int)Mathf.Round(x), (int)Mathf.Round(y), (int)Mathf.Round (sizex), (int)Mathf.Round(sizey), pixelSpacer);
	}

	public Rect x100Rect (int x, int y, int sizex, int sizey = -1, int pixelSpacer=0)
	{
		return new Rect(x*Mathf.Round(Screen.width/100f), 
		                y*Mathf.Round(Screen.height/100f), 
		                sizex*Mathf.Round(Screen.width/100f),
		                sizey*Mathf.Round(Screen.height/100f)-pixelSpacer);
	}

	public Rect[] rectGroup(int count, int x, int y, int x2, int y2, int pixelSpacer = 10)
	{
		float boxHeight = y2 - y;
		float buttonHeight = boxHeight/(count-1);
		Rect[] returnGroup;
		returnGroup = new Rect[count];
		for(int a=0;a<count;a++)
		{
			returnGroup[a] = x100Rect(x,y+buttonHeight*a,
			                          x2-x,buttonHeight, pixelSpacer);
		}
		return returnGroup;
	}
}
