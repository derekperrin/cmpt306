using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationControl : MonoBehaviour {
    protected Rigidbody2D characterRigidBody;
    private bool flipped = false;

    // Use this for initialization
    void Start () {
        characterRigidBody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
		if (characterRigidBody.velocity.x < 0 && flipped == false)
        {
            flipped = true;
            characterRigidBody.transform.localRotation = Quaternion.Euler(0,180,0);
        }
        if (characterRigidBody.velocity.x > 0 && flipped == true)
        {
            flipped = false;
            characterRigidBody.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

    }
}
