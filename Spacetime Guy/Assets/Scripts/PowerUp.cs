using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour {

   protected abstract void startPowerUp(Collider2D collider);

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log(collider.gameObject.name + " has collided with a power up object!");
        startPowerUp(collider);
    }
   protected abstract void startPowerDown();
 
}
