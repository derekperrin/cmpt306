using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour {

   protected abstract void startPowerUp();

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            startPowerUp();
            Destroy(this.gameObject);
        }
    }
   protected abstract void startPowerDown();
 
}
