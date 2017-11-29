using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon {
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

    protected void Initialize(GameObject character, GameObject bulletAsset, float shootRate, float bulletSpeed, float bulletDamage, int maxAmmo, int currentAmmo, float bulletXOffset, float bulletYOffset)
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

    /***
     * This method should call the other Initialize method with appropriate parameters based on the weapon.
     * As an example, see Pistol.cs or MachineGun.cs.
     */
    public abstract void Initialize(GameObject player);

    /***
     * Fire a bullet in Vector2 direction.
     * This method is designed to be called by the FireController method.
     * When called, this method will Instantiate a bullet prefab and fire it in Vector2 direction
     * with speed bulletSpeed (global variable) combined with the velocity of the current velocity 
     * of the rigidbody that is in this GameObject.
     */
    public virtual void Fire(Vector2 direction)
    {
        if (Time.time <= nextShootTime || currentAmmo <= 0) return;
        nextShootTime = Time.time + shootRate;

        // Make sure the weapon has been initialized before shooting it.
        if (character == null)
        {
            Debug.LogError("Error: Cannot fire weapon if it is not initialized.");
            return;
        }

        currentAmmo -= 1;

        GameObject bullet = GameObject.Instantiate(bulletAsset, new Vector3(character.transform.position.x + bulletXOffset, character.transform.position.y + bulletYOffset, character.transform.position.z), Quaternion.identity);
        bullet.GetComponent<Projectile>().setBulletDamage(bulletDamage);
        bullet.GetComponent<Projectile>().from = character.tag;

        //get parent's momentum when firing.
        Vector2 playerVelocity = (character.GetComponent<Rigidbody2D>().velocity);
        int velocityMultiplier = 10;
        
        direction = new Vector2(direction.x == 0 ? playerVelocity.x * velocityMultiplier : direction.x * bulletSpeed, direction.y == 0 ? playerVelocity.y * velocityMultiplier : direction.y * bulletSpeed);

        bullet.GetComponent<Rigidbody2D>().AddForce(direction);
        
    }
}
