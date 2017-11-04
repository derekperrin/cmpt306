using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class character : MonoBehaviour
{

    protected Rigidbody2D characterRigidBody;
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
     * Movement()
     * 
     * Move the character.
     */
    protected abstract void Movement();

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
    
    protected void FixedUpdate()
    {
        Movement();
    }

    

}
