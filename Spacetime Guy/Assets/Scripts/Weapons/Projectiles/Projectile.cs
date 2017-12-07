using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour {

    protected float bulletDamage;
    public string from; // game object that fired bullet

    protected abstract void OnTriggerEnter2D(Collider2D collision);

    public void setBulletDamage(float bulletDamage)
    {
        this.bulletDamage = bulletDamage;
    }
}
