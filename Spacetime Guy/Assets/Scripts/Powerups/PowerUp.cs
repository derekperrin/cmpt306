using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour {
    [SerializeField] protected float powerupLength;
    protected GameObject character;

    protected abstract void startPowerUp(Collider2D collider);

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            startPowerUp(collider);
        }
    }

    protected abstract void startPowerDown();
 
}
