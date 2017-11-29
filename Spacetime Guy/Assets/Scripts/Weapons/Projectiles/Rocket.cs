using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : Projectile {

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == this.from || collision.gameObject.GetComponent<Bullet>() != null)
            return;
        this.GetComponent<CircleCollider2D>().enabled = false;
        this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        InvokeRepeating("Explode", 0, 0.01f);
        Invoke("Delete", 0.4f);


        if (collision.gameObject.GetComponent<Character>() != null) // make sure that it's a Character that we send the message to.
        {
            collision.gameObject.SendMessage("TakeDamage", bulletDamage);
        }
        

    }

    private void Explode()
    {
        this.transform.localScale = new Vector3(this.transform.localScale.x * 1.1f, this.transform.localScale.y * 1.1f, this.transform.localScale.z);
    }

    private void Delete()
    {
        Destroy(this.gameObject);
    }
}
