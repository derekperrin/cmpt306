using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : character {

    protected override void Start()
    {
        heroRigidBody = GetComponent<Rigidbody2D>();
        health = 3f;
        immortal = false;
        lives = 1;
    }

    protected override void GetInput(ref float movementX, ref float movementY)
    {
        movementX = Input.GetAxis("Horizontal");  //A(negative) D(positive) arrow keys 
        movementY = Input.GetAxis("Vertical");  //S(negative) W(positive) arrow keys 
    }
    protected override void Die()
    {
        throw new System.NotImplementedException();
       //Player cannot move
       //Scene changes to end game screen (play again, quit etc)
    }
}
