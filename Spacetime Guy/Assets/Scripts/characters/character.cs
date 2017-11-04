using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class character : MonoBehaviour
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


    protected abstract void Start();

    /***
     * Movement()
     * 
     * Move the character.
     */
    protected abstract void Movement();

    protected void TakeDamage(float damage)
    {
        if (healthMax == 0) // if immortal
            return;
        healthCurrent = healthCurrent - damage;
        if (healthCurrent <= 0)
        {
            //Handle some stuff with lives
            if (lives <= 0)
                Die();
            else {
                lives = lives - 1;
                healthCurrent = healthMax;
            }
        }
    }

    protected abstract void Die();

    protected abstract void FireController();

    protected void Fire(Vector2 direction)
    {

        Rigidbody2D bPrefab = Instantiate(bulletAsset, new Vector3(transform.position.x + bulletXOffset, transform.position.y + bulletYOffset, transform.position.z), Quaternion.identity) as Rigidbody2D;
        //get parent's momentium when firing.
        Vector2 playerVelocity = (this.GetComponent<Rigidbody2D>().velocity);
        int velocityMultiplier = 10;


        direction = new Vector2(direction.x == 0 ? playerVelocity.x * velocityMultiplier : direction.x, direction.y == 0 ? playerVelocity.y * velocityMultiplier : direction.y);

        bPrefab.GetComponent<Rigidbody2D>().AddForce(direction);
        shootCooldown = Time.time + shootRate;
    }

    protected void FixedUpdate()
    {
        Movement();
    }

    protected void Update()
    {
        FireController();
    }

}
