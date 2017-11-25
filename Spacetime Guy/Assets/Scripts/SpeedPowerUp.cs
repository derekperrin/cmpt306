using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : PowerUp {

    private GameObject character;
    [SerializeField]
    private float speedMultiplier;
    [SerializeField]
    private float powerupLength;
    private float originalSpeed;

    protected override void startPowerUp(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            character = GameObject.FindGameObjectWithTag("Player");
            originalSpeed = character.GetComponent<Player>().characterSpeed;
            character.GetComponent<Player>().characterSpeed *= speedMultiplier;
            Invoke("startPowerDown", powerupLength);
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            this.gameObject.GetComponent<CircleCollider2D>().enabled = false;
        }
    }
    

    protected override void startPowerDown()
    {
        Debug.Log("Powering down...");
        character.GetComponent<Rigidbody2D>().GetComponent<Player>().characterSpeed = originalSpeed;
        Destroy(this.gameObject);
    }
       
}
