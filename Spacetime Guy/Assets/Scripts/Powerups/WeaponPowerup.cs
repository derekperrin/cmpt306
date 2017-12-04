using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponPowerup<WeaponSubType> : PowerUp where WeaponSubType : Weapon, new()
{
    private Weapon powerupWeapon;

    protected override void startPowerUp(Collider2D collider)
    {
        if (collider.gameObject.tag != "Player") return;
        Debug.Log("Changing weapon.");
        character = GameObject.FindGameObjectWithTag("Player");
        powerupWeapon = new WeaponSubType();
        powerupWeapon.Initialize(character);
        if (!character.GetComponent<Character>().AddWeapon(powerupWeapon))
            return;

        Destroy(this.gameObject);
    }

    protected override void startPowerDown()
    {
        
    }
}
