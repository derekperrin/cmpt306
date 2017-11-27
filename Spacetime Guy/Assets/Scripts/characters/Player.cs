using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/***
 * GameObject requirements for this script:
 *   - The Game Object that this script is placed in must have a rigidbody2d component.
 */
public class Player : Character {

    protected override void Start()
    {
        characterRigidBody = GetComponent<Rigidbody2D>();
        stunned = false;
        currentWeapon = new Pistol();
        currentWeapon.Initialize(this.gameObject);
    }

    protected override void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        characterRigidBody.velocity = new Vector2(horizontal * characterSpeed, vertical * characterSpeed);
    }

    protected override void Die()
    {
        throw new System.NotImplementedException();
       // TODO: Player cannot move
       // TODO: Scene changes to end game screen (play again, quit etc)
    }

    protected override void FireController()
    {
        if (Input.GetButton("FireX"))
        {
            float shootDirX = Input.GetAxisRaw("FireX");
            Vector2 xMoveVec = new Vector2((shootDirX)/* * bulletSpeed*/, 0);
            currentWeapon.Fire(xMoveVec);
            //Fire(xMoveVec);
        }
        else if (Input.GetButton("FireY"))
        {
            float shootDirY = Input.GetAxisRaw("FireY");
            Vector2 yMoveVec = new Vector2(0, (shootDirY)/* * bulletSpeed*/);
            currentWeapon.Fire(yMoveVec);
            //Fire(yMoveVec);
        }
        
    }
}
