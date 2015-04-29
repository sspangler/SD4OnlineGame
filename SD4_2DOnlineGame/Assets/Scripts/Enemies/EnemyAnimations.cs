using UnityEngine;
using System.Collections;

public class EnemyAnimations : MonoBehaviour {

    Animator anim;

    bool isMoving;
    bool isRight;

    void Awake()
    {
        //Gets Animator component
        if (GetComponent<Animator>() != null)
            anim = GetComponent<Animator>();
    }

	// Use this for initialization
	void Start () {
        isRight = true;
	}
	
	// Update is called once per frame
	void Update () {
        updateSpriteAnimation();
	}

    public void updateSpriteDirection()
    {
        isRight = !isRight;

        //Get the current scale of the transform
        Vector3 currScale = transform.localScale;

        //Set the X-scale to face oppositer direction
        currScale.x *= -1;

        //Set the scale of the player transform to the altered currScale
        transform.localScale = currScale;
    }

    void updateSpriteAnimation()
    {
        //Tells animator if the player is moving or not
        if (anim != null)
        {
            anim.SetBool("isMoving", isMoving);
        }
    }

    public void setMoving(bool b)
    {
        isMoving = b;
    }

    public bool getDirection()
    {
        return isRight;
    }
}
