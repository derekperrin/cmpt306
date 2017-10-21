using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class character : MonoBehaviour
{

    protected Rigidbody2D heroRigidBody;
    [SerializeField]
    protected float speed;

    //Health values for the player + characters
    protected float health;
    //Boolean to make players undamagable/unkillable 
    protected bool immortal;
    //number for amount of 'lives'character has. starts with one (usually), but can add more through items etc.
    protected int lives;

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

    protected void TakeDamage(float damage)
    {
        if (immortal){
            damage = 0;
        }
        health = health - damage;
        if (health <= 0)
        {
            //Handle some stuff with lives
            lives = lives - 1;
            if (lives <= 0)
            {
                //  Die();
            }
        }
    }

    protected abstract void Die();
        
       
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
