using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour {

    public static GlobalControl Instance;
    public float playerHealth;
    public Weapon playerWeapon;
    public int levelsCompleted;
	// Use this for initialization
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
                playerWeapon = player.currentWeapon;
                levelsCompleted = player.levelsBeaten;
            }
        }
    }

    void ResetPlayerState()
    {
        playerHealth = 100;
        //playerWeapon = new Pistol();
        levelsCompleted = 0;
    }


    // Update is called once per frame
    //void Update () {
	//	
	//}
}
