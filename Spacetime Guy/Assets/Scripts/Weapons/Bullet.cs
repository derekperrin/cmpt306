﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [SerializeField]
    private float bulletDamage; 
    public string from; // game object that fired bullet

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != this.from)
        {
            if (!collision.gameObject.name.StartsWith("wall"))
            {
                collision.gameObject.SendMessage("TakeDamage", bulletDamage);
            }
            Destroy(this.gameObject);
        }
    }

}