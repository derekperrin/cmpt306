using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : character {

    protected override void Start()
    {
        characterRigidBody = GetComponent<Rigidbody2D>();
        health = 3f;
        immortal = false;
        lives = 1;
    }

    protected override void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontal, vertical);

        characterRigidBody.velocity = new Vector2(horizontal * speed, characterRigidBody.velocity.y);
        characterRigidBody.velocity = new Vector2(characterRigidBody.velocity.x, vertical * speed);
    }

    protected override void Die()
    {
        throw new System.NotImplementedException();
       //Player cannot move
       //Scene changes to end game screen (play again, quit etc)
    }
}
