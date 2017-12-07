using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/***
 * GameObject requirements for this class:
 *   - Each game object that implements a child of this abstract class must have a rigidbody2d component in order to
 *     use the Fire() method.
 */
public abstract class Character : MonoBehaviour
{
    // Character variables
    protected Rigidbody2D characterRigidBody;
    [SerializeField]
    public float characterSpeed;
    [SerializeField]
    public float healthCurrent;
    [SerializeField]
    public float healthMax; // set to 0 to be immortal
    [SerializeField]
    protected int lives;
    protected bool stunned;

    //public Weapon currentWeapon;

    public Weapon[] Weapons;
    public bool[] WeaponsInUse;
    [SerializeField]
    public int maxNumWeapons;
    public int numWeapons = 0;
    public int currentWeapon;

    /***
     * The user is required to initialize the characterRigidBody global variable
     */
    protected abstract void Start();

    /***
     * Movement()
     * 
     * Move the character.
     */
    protected abstract void Movement();

    /***
     * When something collides with the character, the thing that collides with the character should send a message
     * to call this method
     */
    virtual protected void TakeDamage(float damage)
    {
        if (healthMax == 0) // if immortal
            return;
        healthCurrent = healthCurrent - damage > healthMax ? healthMax : healthCurrent - damage;
        if (healthCurrent <= 0)
        {
            lives = lives - 1;
            //Handle some stuff with lives
            if (lives <= 0)
                Die();
            else {
                healthCurrent = healthMax;
            }
        }
    }

    /***
     * The Die method.
     * This method is called by TakeDamage() and must be implemented in a child class.
     */
    protected abstract void Die();

    /***
     * This method must be implemented by a child class.
     * 
     * This method should be implemented to control how and when the method Fire() is 
     * called. This method is responsible for creating and supplying the Vector2 
     * direction variable to Fire(). This method is called every time the game updates
     * using the Update() method.
     * 
     * If the child class does not need to fire a weapon, leave the implementation of
     * this method blank.
     */
    protected abstract void FireController();

    // stun player when hit
    public void Stun(float stunTime)
    {
        this.stunned = true;
        Invoke("UnStun", stunTime);
    }

    // un-stun player
    private void UnStun()
    {
        this.stunned = false;
    }

    protected void FixedUpdate()
    {
        if (!this.stunned)
        {
            Movement();
        }
    }

    protected virtual void Update()
    {
        FireController();
    }

    /***
     * Change the currentWeapon to newWeapon.
     * Return the original value of currentWeapon.
     *//*
    public Weapon changeWeapon(Weapon newWeapon)
    {
        Weapon originalWeapon = currentWeapon;
        currentWeapon = newWeapon;
        return originalWeapon;
    }*/

    public void ToggleWeapon()
    {
        int i = 0;
        do
        {
            currentWeapon = currentWeapon + 1 >= maxNumWeapons ? 0 : currentWeapon + 1;
            if (++i > maxNumWeapons)
            {
                Debug.LogError("Could not toggle to next weapon.");
                break;
            }
        }
        while (!WeaponsInUse[currentWeapon]);
    }

    /*** 
     * returns true if the weapon was added,
     * false otherwise
     */
    public bool AddWeapon(Weapon weapon)
    {
        if (numWeapons >= maxNumWeapons) return false;
        numWeapons += 1;
        for (currentWeapon = 0; WeaponsInUse[currentWeapon]; currentWeapon += 1);
        WeaponsInUse[currentWeapon] = true;
        Weapons[currentWeapon] = weapon;
        return true;
    }

    public void RemoveWeapon(int weaponId)
    {
        if (weaponId >= maxNumWeapons || weaponId < 0)
        {
            Debug.LogError("Invalid Weapon ID to remove.");
            return;
        }
        WeaponsInUse[weaponId] = false;
        numWeapons -= 1;
        Debug.Log("Weapon ID: " + weaponId + ". currentWeapon: " + currentWeapon + ".");
        if (currentWeapon == weaponId)
        {
            ToggleWeapon();
        }
    }

    /***
     * Return the weapon ID if found.
     * If not found, return -1
     */
    public int getWeaponId(Weapon weapon)
    {
        int id;
        bool found = false;
        for (id = 0; id < maxNumWeapons; id += 1)
        {
            if (Weapons[id].Equals(weapon))
            {
                found = true;
                break;
            }
        }
        if (!found) return -1; //If the weapon was not found.
        return id;
    }

    public float getCurrentHealth()
    {
        return healthCurrent;
    }

    public float getMaxHealth()
    {
        return healthMax;
    }
}
