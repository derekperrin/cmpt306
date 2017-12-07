using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/***
 * GameObject requirements for this script:
 *   - The Game Object that this script is placed in must have a rigidbody2d component.
 */
public class Player : Character {
    //the UI Game Object dedicated to show the player's hp.
    protected GameObject HealthUI;

    //the UI Game Object dedicated to show player's weapon ammo
    protected GameObject WeaponUI;
    // player holds a log of it's levels beaten so it can save and get from globalvar for score purposes.
    public int levelsBeaten;

    //public GameObject lighting;

    protected override void Start()
    {
        characterRigidBody = GetComponent<Rigidbody2D>();
        stunned = false;
        healthCurrent *= 4;
        healthMax *= 4;
        /*
        if (GlobalControl.Instance.playerWeapon == null)
        {
            currentWeapon = new Pistol();
        }
        else
        {
            currentWeapon = GlobalControl.Instance.playerWeapon;
        }*/

        Weapons = new Weapon[maxNumWeapons];
        WeaponsInUse = new bool[maxNumWeapons];

        if (GlobalControl.Instance.playerWeapons == null)
        {
            if (AddWeapon(new Pistol()) == false)
            {
                Debug.LogError("Could not create player's first weapon.");
            }
            else
            {
                Weapons[currentWeapon].Initialize(this.gameObject);
            }
        }
        else
        {
            for (int i = 0; i < Weapons.Length; i += 1)
            {
                Weapons[i] = GlobalControl.Instance.playerWeapons[i];
                Weapons[i].Initialize(this.gameObject);
                WeaponsInUse[i] = GlobalControl.Instance.playerWeaponStates[i];
                numWeapons = GlobalControl.Instance.playerNumWeapons;
            }
        }
        healthCurrent = GlobalControl.Instance.playerHealth;
        levelsBeaten = GlobalControl.Instance.levelsCompleted;
        HealthUI = GameObject.FindGameObjectWithTag("HealthUI");
        HealthUI.SendMessage("UpdateUI");
        WeaponUI = GameObject.FindGameObjectWithTag("WeaponUI");
        WeaponUI.SendMessage("UpdateUI");

        //var temp = Instantiate(lighting, new Vector2(characterRigidBody.position.x, characterRigidBody.position.y), new Quaternion(0,0,0,0));
        //temp.transform.parent = transform;
    }

    protected override void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        characterRigidBody.velocity = new Vector2(horizontal * characterSpeed, vertical * characterSpeed);
    }

    protected override void Die()
    {
        Time.timeScale = 0;
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }

    protected override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        HealthUI.SendMessage("UpdateUI");
    }

    protected override void FireController()
    {
        if (Input.GetButtonDown("ToggleWeapon"))
        {
            ToggleWeapon();
            WeaponUI.SendMessage("UpdateUI");
        }
        else if (Input.GetButton("FireX"))
        {
            float shootDirX = Input.GetAxisRaw("FireX");
            Vector2 xMoveVec = new Vector2((shootDirX), 0);
            //currentWeapon.Fire(xMoveVec);
            Weapons[currentWeapon].Fire(xMoveVec);
            WeaponUI.SendMessage("UpdateUI");
        }
        else if (Input.GetButton("FireY"))
        {
            float shootDirY = Input.GetAxisRaw("FireY");
            Vector2 yMoveVec = new Vector2(0, (shootDirY));
            //currentWeapon.Fire(yMoveVec);
            Weapons[currentWeapon].Fire(yMoveVec);
            WeaponUI.SendMessage("UpdateUI");
        }

    }
}
