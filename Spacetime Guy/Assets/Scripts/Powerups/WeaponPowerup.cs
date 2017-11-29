using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponPowerup<WeaponSubType> : PowerUp where WeaponSubType : Weapon, new()
{
    private static bool hasWeaponPowerup = false;

    private Weapon originalWeapon;

    protected override void startPowerUp(Collider2D collider)
    {
        if (collider.gameObject.tag != "Player") return;
        if (hasWeaponPowerup) return;
        hasWeaponPowerup = true;
        Debug.Log("Changing weapon.");
        character = GameObject.FindGameObjectWithTag("Player");
        Weapon newWeapon = new WeaponSubType();
        newWeapon.Initialize(character);
        originalWeapon = character.GetComponent<Character>().changeWeapon(newWeapon);

        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        this.gameObject.GetComponent<CircleCollider2D>().enabled = false;

        Invoke("startPowerDown", powerupLength);
    }

    protected override void startPowerDown()
    {
        Debug.Log("Changing weapon back.");
        character.GetComponent<Character>().changeWeapon(originalWeapon);
        hasWeaponPowerup = false;
        Destroy(this.gameObject);
    }
}
