using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon {
    private GameObject character;
    private GameObject bulletAsset;
    protected float shootRate;
    protected float bulletSpeed;
    protected float bulletDamage;
    protected int maxAmmo;
    protected int currentAmmo;
    private float bulletXOffset;
    private float bulletYOffset;

    protected float nextShootTime;


    protected Weapon(GameObject character, GameObject bulletAsset, float shootRate, float bulletSpeed, float bulletDamage, int maxAmmo, int currentAmmo, float bulletXOffset, float bulletYOffset)
    {
        this.character = character;
        this.bulletAsset = bulletAsset;
        this.shootRate = shootRate;
        this.bulletSpeed = bulletSpeed;
        this.bulletDamage = bulletDamage;
        this.maxAmmo = maxAmmo;
        this.currentAmmo = currentAmmo;
        this.bulletXOffset = bulletXOffset;
        this.bulletYOffset = bulletYOffset;

        this.nextShootTime = Time.time;
        
        
    }


    public virtual void Fire(Vector2 direction)
    {
        if (Time.time <= nextShootTime && currentAmmo > 0) return;
        
        nextShootTime = Time.time + shootRate;
        currentAmmo -= 1;

        GameObject bullet = GameObject.Instantiate(bulletAsset, new Vector3(character.transform.position.x + bulletXOffset, character.transform.position.y + bulletYOffset, character.transform.position.z), Quaternion.identity);
        bullet.GetComponent<Bullet>().setBulletDamage(bulletDamage);
        bullet.GetComponent<Bullet>().from = character.tag;

        //get parent's momentum when firing.
        Vector2 playerVelocity = (character.GetComponent<Rigidbody2D>().velocity);
        int velocityMultiplier = 10;
        
        direction = new Vector2(direction.x == 0 ? playerVelocity.x * velocityMultiplier : direction.x * bulletSpeed, direction.y == 0 ? playerVelocity.y * velocityMultiplier : direction.y * bulletSpeed);

        bullet.GetComponent<Rigidbody2D>().AddForce(direction);
        
    }
}
