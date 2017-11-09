using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : PowerUp {

    private float speedMultiplier = 1.4f;

    protected override void startPowerUp()
    {
        Rigidbody2D temp;
        temp = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        temp.velocity = temp.velocity * speedMultiplier;
        
    }
      

    protected override void startPowerDown()
    {

    }
       
}
