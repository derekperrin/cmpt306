﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour {

    public static GlobalControl Instance;
    public float playerHealth;
    public int playerCurrentWeaponIndex;
    public Weapon[] playerWeapons;
    public bool[] playerWeaponStates;
    public int levelsCompleted;
    public int playerNumWeapons;
	
	void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    void GetPlayerState()
    {
        if (GlobalControl.Instance != null)
        {
            Player player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            if (player != null)
            {
                playerHealth = player.healthCurrent;
                playerCurrentWeaponIndex = player.currentWeapon;
                levelsCompleted = player.levelsBeaten;
                playerWeapons = new Weapon[player.Weapons.Length];
                playerWeaponStates = new bool[player.WeaponsInUse.Length];
                playerNumWeapons = player.numWeapons;
                for (int i = 0; i < player.Weapons.Length; i += 1)
                {
                    playerWeapons[i] = player.Weapons[i];
                    playerWeaponStates[i] = player.WeaponsInUse[i];
                }
            }
        }
    }

    void ResetPlayerState()
    {
        playerHealth = 100;
        //playerWeapon = new Pistol();
        levelsCompleted = 0;
    }

    void IncrementLevelCompleted()
    {
        levelsCompleted = levelsCompleted + 1;
    }


    // Update is called once per frame
    //void Update () {
	//	
	//}
}
