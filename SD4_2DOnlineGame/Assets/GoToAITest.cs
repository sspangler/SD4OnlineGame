using UnityEngine;
using System.Collections;

public class GoToAITest : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Application.loadedLevelName != "AI Test" &&
            Input.GetKeyDown(KeyCode.Space)) {
            Application.LoadLevel("AI Test");
            Destroy(this);
        }
        if (Application.loadedLevelName != "AI Test" &&
            Input.GetKeyDown(KeyCode.LeftShift)) {
            Application.LoadLevel("LargerTerrainTest");
            Destroy(this);
        }
	}
}
