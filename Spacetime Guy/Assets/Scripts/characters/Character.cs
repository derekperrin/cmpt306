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
    protected float characterSpeed;
    [SerializeField]
    protected float healthCurrent;
    [SerializeField]
    protected float healthMax; // set to 0 to be immortal
    [SerializeField]
    protected int lives;
    protected bool stunned;

    // Bullet Variables
    [SerializeField]
    private Rigidbody2D bulletAsset; // To be set in Unity
    [SerializeField]
    protected float shootRate; // To be set in Unity
    protected float shootCooldown; // To be set in Unity
    [SerializeField]
    protected float bulletSpeed;

    //these are used to make it look like it's shot from whatever it needs to be shot
    [SerializeField]
    private float bulletXOffset;
    [SerializeField]
    private float bulletYOffset;

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
    protected void TakeDamage(float damage)
    {
        if (healthMax == 0) // if immortal
            return;
        healthCurrent = healthCurrent - damage;
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

    /***
     * Fire a bullet in Vector2 direction.
     * This method is designed to be called by the FireController method.
     * When called, this method will Instantiate a bullet prefab and fire it in Vector2 direction
     * with speed bulletSpeed (global variable) combined with the velocity of the current velocity 
     * of the rigidbody that is in this GameObject.
     */
    protected void Fire(Vector2 direction)
    {
        Rigidbody2D bPrefab = Instantiate(bulletAsset, new Vector3(transform.position.x + bulletXOffset, transform.position.y + bulletYOffset, transform.position.z), Quaternion.identity) as Rigidbody2D;
        bPrefab.GetComponent<Bullet>().from = gameObject.tag;
        //get parent's momentum when firing.
        Vector2 playerVelocity = (this.GetComponent<Rigidbody2D>().velocity);
        int velocityMultiplier = 10;


        direction = new Vector2(direction.x == 0 ? playerVelocity.x * velocityMultiplier : direction.x, direction.y == 0 ? playerVelocity.y * velocityMultiplier : direction.y);

        bPrefab.GetComponent<Rigidbody2D>().AddForce(direction);
        shootCooldown = Time.time + shootRate;
    }

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

}
