﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Projectile {

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == this.from || collision.gameObject.GetComponent<Bullet>() != null)
            return;
        
        if (collision.gameObject.GetComponent<Character>() != null) // make sure that it's a Character that we send the message to.
        {
            collision.gameObject.SendMessage("TakeDamage", bulletDamage);
        }
        Destroy(this.gameObject);
        
    }
}
