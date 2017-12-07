using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHealth : PowerUp {
    [SerializeField] private float healthBoost;

    protected override void startPowerUp(Collider2D collider)
    {
        collider.gameObject.SendMessage("TakeDamage", -healthBoost);
        GameObject.FindGameObjectWithTag("HealthUI").SendMessage("UpdateUI");
        Destroy(this.gameObject);
    }

    protected override void startPowerDown()
    {
        throw new System.NotImplementedException();
    }
}
