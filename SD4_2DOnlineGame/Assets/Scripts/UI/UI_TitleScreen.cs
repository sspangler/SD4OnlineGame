using UnityEngine;
using System.Collections;

public class UI_TitleScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void PlayButton(string name)
    {
        //Go to class select screen
        Application.LoadLevel("MainMenu");
    }

    public void QuitButton(string name)
    {
        Application.Quit();
    }
}
