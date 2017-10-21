using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster : character {

    private int directionX;
    private int directionY;

	// Use this for initialization
	protected override void Start () {
        heroRigidBody = GetComponent<Rigidbody2D>();
        health = 1f;
        lives = 1;
        immortal = false;
        directionX = directionY = 1;
	}

    protected override void GetInput(ref float movementX, ref float movementY)
    {
        if (heroRigidBody.position.x * directionX > 4) directionX = -directionX;
        if (heroRigidBody.position.y * directionY > 4) directionY = -directionY;
        movementX = 0.1f * directionX;
        movementY = 0.1f * directionY;
    }

    protected override void Die()
    {
        Destroy(this.gameObject);
    }
}
