﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/***
 * GameObject requirements for this script:
 *   - The Game Object that this script is placed in must have a rigidbody2d component.
 *   - A single game object with name playerToKillName (set in unity) must exist in the game.
 */
public class Monster : Character {

    [SerializeField]
    private string playerToKillName;
    private GameObject playerToKill;
    [SerializeField]
    private float attack;
    [SerializeField]
    private float pushForce;

    protected override void Start() {
       
   
        
        characterRigidBody = GetComponent<Rigidbody2D>();
	}
    protected override void Update()
    {
        if (GameObject.FindGameObjectWithTag(playerToKillName)!=null)
        {
            playerToKill = GameObject.FindGameObjectWithTag(playerToKillName);
        }
    }

    protected override void Movement()
    {
        try {
            
            characterRigidBody.velocity = (playerToKill.transform.position - this.gameObject.transform.position).normalized * this.characterSpeed;
            
        } catch(System.NullReferenceException e)
        {

        }
            
            
            
            //Quaternion rotation = Quaternion.LookRotation(playerToKill.transform.position - this.transform.position, this.transform.TransformDirection(Vector3.up));
        //this.transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
    }

    protected override void Die()
    {
        Destroy(this.gameObject);
    }

    protected override void FireController()
    {
        // This monster does not shoot.
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Used mainly for when the monster crashes into the player
        if (collision.gameObject.tag == "Player")
        {
            // Debug.Log("Monster has struck player");
            playerToKill.SendMessage("TakeDamage", attack);
            playerToKill.GetComponent<Player>().Stun(1.0f);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(this.characterRigidBody.velocity.normalized * pushForce);
            characterRigidBody.velocity = new Vector2(0f, 0f);
            this.Stun(1.0f);
        }
    }
}
