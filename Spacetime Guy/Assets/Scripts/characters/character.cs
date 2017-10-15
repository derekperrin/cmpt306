using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class character : MonoBehaviour
{

    protected Rigidbody2D heroRigidBody;
    [SerializeField]
    protected float speed;

    protected abstract void Start();

    /***
     * GetInput(ref float movementX, ref float movementY)
     * 
     * Get the character input and place the x movement in movementX and place the y movement in movementY
     */
    protected abstract void GetInput(ref float movementX, ref float movementY);

    /***
     * Movement(float horizonal, float vertical)
     * 
     * Move the character.
     */
    protected void Movement(float horizontal, float vertical)
    {
        Vector2 movement = new Vector2(horizontal, vertical);

        heroRigidBody.velocity = new Vector2(horizontal * speed, heroRigidBody.velocity.y);
        heroRigidBody.velocity = new Vector2(heroRigidBody.velocity.x, vertical * speed);
    }

    /***
     * Move the character
     */
    protected void FixedUpdate()
    {
        float movementX = 0;
        float movementY = 0;
        GetInput(ref movementX, ref movementY);
        Movement(movementX, movementY);
    }

    

}
