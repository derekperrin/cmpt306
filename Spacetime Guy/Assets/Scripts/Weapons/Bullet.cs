using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    
    private float bulletDamage; 
    public string from; // game object that fired bullet

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != this.from)
        {
            if (collision.gameObject.GetComponent<Character>() != null) // make sure that it's a Character that we send the message to.
            {
                collision.gameObject.SendMessage("TakeDamage", bulletDamage);
            }
            Destroy(this.gameObject);
        }
    }

    public void setBulletDamage(float bulletDamage)
    {
        this.bulletDamage = bulletDamage;
    }

}
