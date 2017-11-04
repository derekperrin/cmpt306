using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster : character {

    public string playerToKillName;
    private GameObject playerToKill;    

    protected override void Start() {
        playerToKill = GameObject.Find(playerToKillName);
        characterRigidBody = GetComponent<Rigidbody2D>();
	}

    protected override void Movement()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, playerToKill.transform.position, characterSpeed * Time.deltaTime);

        Quaternion rotation = Quaternion.LookRotation(playerToKill.transform.position - this.transform.position, this.transform.TransformDirection(Vector3.up));
        this.transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
    }

    protected override void Die()
    {
        Destroy(this.gameObject);
    }

    protected override void FireController()
    {
        // This monster does not shoot.
    }
}
