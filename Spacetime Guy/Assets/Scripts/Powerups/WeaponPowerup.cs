using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponPowerup<WeaponSubType> : PowerUp where WeaponSubType : Weapon, new()
{
    private static bool hasWeaponPowerup = false;

    private Weapon originalWeapon;
    private Weapon powerupWeapon;

    private void checkAmmo()
    {
        if (powerupWeapon.currentAmmo <= 0)
        {
            startPowerDown();
        }
    }

    protected override void startPowerUp(Collider2D collider)
    {
        if (collider.gameObject.tag != "Player") return;
        if (hasWeaponPowerup) return;
        hasWeaponPowerup = true;
        Debug.Log("Changing weapon.");
        character = GameObject.FindGameObjectWithTag("Player");
        powerupWeapon = new WeaponSubType();
        powerupWeapon.Initialize(character);
        originalWeapon = character.GetComponent<Character>().changeWeapon(powerupWeapon);
        GameObject.FindGameObjectWithTag("WeaponUI").SendMessage("UpdateUI");

        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        this.gameObject.GetComponent<CircleCollider2D>().enabled = false;

        Invoke("startPowerDown", powerupLength);
        InvokeRepeating("checkAmmo", 0.5f, 0.5f);
    }

    protected override void startPowerDown()
    {
        Debug.Log("Changing weapon back.");
        character.GetComponent<Character>().changeWeapon(originalWeapon);
        GameObject.FindGameObjectWithTag("WeaponUI").SendMessage("UpdateUI");
        hasWeaponPowerup = false;
        Destroy(this.gameObject);
    }
}
