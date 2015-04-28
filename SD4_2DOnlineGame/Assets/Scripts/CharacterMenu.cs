using UnityEngine;
using System.Collections;

public class CharacterMenu : MonoBehaviour {

	public GameObject text;
	string characterName = "";
	int selectedClass = -1;
	int maxCharLength = 16;
	int timer = 0;
	int cycle = 40;
	int flashOn = 15;
	gameManager gameManagerRef;

	// Use this for initialization
	void Awake () {
		gameManagerRef = GameObject.Find ("GameManager").GetComponent<gameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		timer += 1;
		if (Input.inputString != "")
		{
			characterName += Input.inputString;
			if(characterName.Length>maxCharLength)
				characterName = characterName.Remove(16);
		}
		if(Input.GetKeyDown(KeyCode.Backspace)&&characterName.Length>1)
			characterName = characterName.Remove(characterName.Length-2);

		if ((timer % cycle) <= flashOn)
			text.GetComponent<TextMesh> ().text = characterName + "|";
		else
			text.GetComponent<TextMesh> ().text = characterName;
	}

	void OnGUI()
	{
		if(GUI.Button(x100Rect(20f, 30f, 25f, 20f), gameManagerRef.classes[0]))
		{
			selectedClass = 0;
		}
		if(GUI.Button(x100Rect(55f, 30f, 25f, 20f), gameManagerRef.classes[1]))
		{
			selectedClass = 1;
		}
		if(GUI.Button(x100Rect(20f, 55f, 25f, 20f), gameManagerRef.classes[2]))
		{
			selectedClass = 2;
		}
		if(GUI.Button(x100Rect(55f, 55f, 25f, 20f), gameManagerRef.classes[3]))
		{
			selectedClass = 3;
		}

		if (selectedClass != -1 && characterName!="") {
			if (GUI.Button (x100Rect (35f, 80f, 30f, 15f), "Create " + gameManagerRef.classes[selectedClass])) {
				// Create character save file
				usave_file charSave = gameManagerRef.charSaveObj.GetComponent<usave_file>();
				gameManagerRef.createCharacter(selectedClass, characterName);

				Application.LoadLevel("MainMenu");
			}
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
}
