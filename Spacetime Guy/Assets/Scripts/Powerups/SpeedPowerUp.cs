using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : PowerUp {

    [SerializeField]
    private float speedMultiplier;

    protected override void startPowerUp(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            character = GameObject.FindGameObjectWithTag("Player");
            character.GetComponent<Player>().characterSpeed *= speedMultiplier;
            Invoke("startPowerDown", powerupLength);
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            this.gameObject.GetComponent<CircleCollider2D>().enabled = false;
        }
    }
    

    protected override void startPowerDown()
    {
        character.GetComponent<Rigidbody2D>().GetComponent<Player>().characterSpeed /= speedMultiplier;
        Destroy(this.gameObject);
    }
       
}
