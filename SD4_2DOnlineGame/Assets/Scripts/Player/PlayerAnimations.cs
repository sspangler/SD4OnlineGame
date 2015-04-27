﻿using UnityEngine;
using System.Collections;

public class PlayerAnimations : MonoBehaviour {

    /// <summary>
    /// animDir - value used to control the direction of the player's on-screen images
    /// 2 = back (north)
    /// -1, 1 = side (west, east)
    /// 0 = front (south)
    /// </summary>
    public int animDir;

    Animator anim;
    bool isRight;

    playercontroller playerInfo;

    void Awake() {
        //Gets Animator component
        if (GetComponent<Animator>() != null)
            anim = GetComponent<Animator>();

        //Gets playercontroller component
        if (GetComponent<playercontroller>() != null)
            playerInfo = GetComponent<playercontroller>();
    }

	// Use this for initialization
	void Start () {
        isRight = true;
	}
	
	// Update is called once per frame
	void Update () {
        updateAnimDir();
        updateSpriteAnimation();
	}

    void updateAnimDir() {
        if (Input.GetKey(KeyCode.W))
        {
            animDir = 2;
        }

        if (Input.GetKey(KeyCode.S))
        {
            animDir = 0;
        }

        if (Input.GetKey(KeyCode.D))
        {
            animDir = 1;

            if (!isRight) updateSpriteDirection();
        }

        if (Input.GetKey(KeyCode.A))
        {
            animDir = -1;

            if (isRight) updateSpriteDirection();
        }
    }

    void updateSpriteDirection() {
        isRight = !isRight;

        //Get the current scale of the transform
        Vector3 currScale = transform.localScale;

        //Set the X-scale to face oppositer direction
        currScale.x *= -1;

        //Set the scale of the player transform to the altered currScale
        transform.localScale = currScale;
    }

    void updateSpriteAnimation() {
        //Tells animator the current animation direction
        anim.SetInteger("animDir", animDir);

        //Tells animator if the player is moving or not
        anim.SetBool("isMoving", playerInfo.isMoving);
    }
}
