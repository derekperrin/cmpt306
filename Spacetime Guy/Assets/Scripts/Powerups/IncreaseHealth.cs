using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseHealth : PowerUp {

    protected override void startPowerUp(Collider2D collider)
    {
        GameObject.FindGameObjectWithTag("HealthUI").SendMessage("AddHeartContainer");
        Destroy(this.gameObject);
    }

    protected override void startPowerDown()
    {
        throw new System.NotImplementedException();
    }
}
