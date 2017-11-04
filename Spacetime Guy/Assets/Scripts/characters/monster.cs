using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster : character {

    public string playerName;
    private GameObject playerToKill;

    private int directionX;
    private int directionY;

    

    protected override void Start() {
        playerToKill = GameObject.Find(playerName);
        characterRigidBody = GetComponent<Rigidbody2D>();
        health = 1f;
        lives = 1;
        immortal = false;
        directionX = directionY = 1;
	}

    protected override void Movement()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, playerToKill.transform.position, speed * Time.deltaTime);

        Quaternion rotation = Quaternion.LookRotation(playerToKill.transform.position - this.transform.position, this.transform.TransformDirection(Vector3.up));
        this.transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
    }

    protected override void Die()
    {
        Destroy(this.gameObject);
    }
}
