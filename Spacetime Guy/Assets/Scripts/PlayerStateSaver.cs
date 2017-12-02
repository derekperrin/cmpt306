using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateSaver : MonoBehaviour {



    public float playerHealth;
    public Weapon playerWeapon;
    public int levelsCompleted;


    // Use this for initialization
    void Start () {
        playerHealth = GlobalControl.Instance.playerHealth;
        playerWeapon = GlobalControl.Instance.playerWeapon;
        levelsCompleted = GlobalControl.Instance.levelsCompleted;
	}

    // Update is called once per frame
    //void Update () {
    //	
    //}
    //Save Data to Global values;
    public void SavePlayer()
    {
        GlobalControl.Instance.playerHealth = playerHealth;
        GlobalControl.Instance.playerWeapon = playerWeapon;
        GlobalControl.Instance.levelsCompleted = levelsCompleted;
    }

    void getPlayerState()
    {
        if (GlobalControl.Instance != null)
        {
            Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            if (player != null)
            {
                playerHealth = player.healthCurrent;
                playerWeapon = player.currentWeapon;
                levelsCompleted = player.levelsBeaten;
            }
        }
    }
}
