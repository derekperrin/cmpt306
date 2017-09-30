using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour {

    public Rigidbody2D bulletAsset;
    public float fireSpeed;
    public float weaponCooldown;
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
        if (Time.time >= weaponCooldown)
        {
            if (Input.GetButton("Fire+X") || Input.GetButton("Fire-X") || Input.GetButton("Fire+Y") || Input.GetButton("Fire-Y")) { 
                Fire();
            }
        }
    }

    void Fire() {
        Rigidbody2D bPrefab = Instantiate(bulletAsset, new Vector3(transform.position.x + xOffset, transform.position.y + YOffset, transform.position.z), Quaternion.identity) as Rigidbody2D;
        //bPrefab.rigidbody2D.AddForce(Vector2.up * bulletSpeed);
        bPrefab.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bulletSpeed);
            //.addForce(Vector2.up * bulletSpeed);
        weaponCooldown = Time.time + fireSpeed;
	}
}
