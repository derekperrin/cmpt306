using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : character {

    protected override void Start()
    {
        characterRigidBody = GetComponent<Rigidbody2D>();
    }

    protected override void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        characterRigidBody.velocity = new Vector2(horizontal * characterSpeed, characterRigidBody.velocity.y);
        characterRigidBody.velocity = new Vector2(characterRigidBody.velocity.x, vertical * characterSpeed);
    }

    protected override void Die()
    {
        throw new System.NotImplementedException();
       //Player cannot move
       //Scene changes to end game screen (play again, quit etc)
    }

    protected override void FireController()
    {
        if (Time.time >= shootCooldown)
        {
            if (Input.GetButton("FireX"))
            {
                float shootDirX = Input.GetAxisRaw("FireX");
                Vector2 xMoveVec = new Vector2((shootDirX) * bulletSpeed, 0);
                Fire(xMoveVec);
            }
            else if (Input.GetButton("FireY"))
            {
                float shootDirY = Input.GetAxisRaw("FireY");
                Vector2 yMoveVec = new Vector2(0, (shootDirY) * bulletSpeed);
                Fire(yMoveVec);
            }
        }
    }
}
