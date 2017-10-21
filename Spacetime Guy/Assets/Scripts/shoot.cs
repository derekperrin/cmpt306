﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour {

    public Rigidbody2D bulletAsset;
    //this is how fast you can fire
    public float fireSpeed;
    //this is the cooldown/delay of the weapon b/w shots
    public float weaponCooldown;
    //this is how fast the bullet actually FLIES.
    public float bulletSpeed;
    public float xOffset;
    //these are used to make it look like it's shot from whatever it needs to be shot
    public float YOffset;
    //These are also used to make it look like it's shot from whatever it needs to be shot from.
    //public bullet shot;

    //public Transform firepoint;


    // Use this for initialization
    //void Start() {
        //player
        //anim = GetComponent<Animator>();
    //}

    // Update is called once per frame
    void Update() {
        if (Time.time >= weaponCooldown){
            if (Input.GetButton("FireX"))  {
                float shootDirX = Input.GetAxisRaw("FireX");
                Vector2 xMoveVec = new Vector2((shootDirX) * bulletSpeed, 0);
                Fire(xMoveVec);
            } else if (Input.GetButton("FireY")){
               float shootDirY = Input.GetAxisRaw("FireY");
                Vector2 yMoveVec = new Vector2(0,(shootDirY) * bulletSpeed);
                Fire(yMoveVec);
            }
        }
        
    }

    void Fire(Vector2 direction) {
        
  Rigidbody2D bPrefab = Instantiate(bulletAsset, new Vector3(transform.position.x + xOffset, transform.position.y + YOffset, transform.position.z), Quaternion.identity) as Rigidbody2D;
        //get parent's momentium when firing.
        Vector2 playerVelocity = (this.GetComponent<Rigidbody2D>().velocity);
        int velocityMultiplier = 10;


        direction = new Vector2(direction.x == 0 ? playerVelocity.x * velocityMultiplier : direction.x, direction.y == 0 ? playerVelocity.y * velocityMultiplier : direction.y);

        bPrefab.GetComponent<Rigidbody2D>().AddForce(direction);
        weaponCooldown = Time.time + fireSpeed;
	}
}
