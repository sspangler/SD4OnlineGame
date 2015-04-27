using UnityEngine;
using System.Collections;

public class PlayerAnimations : MonoBehaviour {

    /// <summary>
    /// animDir - value used to control the direction of the player's on-screen images
    /// 2 = back (north)
    /// -1, 1 = side (west, east)
    /// 0 = front (south)
    /// </summary>
    int animDir;

    Animator anim;

    void Awake() {
        //Gets Animator component
        if (GetComponent<Animator>() != null)
            anim = GetComponent<Animator>();
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        spriteDirection();
	}

    void spriteDirection() {
        //Get the current scale of the transform
        Vector3 currScale = transform.localScale;

        //If player is facing left or right,
        //set the X-scale to face proper direction based on animDir
        if (animDir ==- 1 || animDir == 1) 
            currScale.x *= animDir;

        //Set the scale of the player transform to the altered currScale
        transform.localScale = currScale;
    }
}
