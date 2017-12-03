using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUI : MonoBehaviour {

    public Text weaponText;
    private Player target;
    // Use this for initialization
    void Start () {
        	
    }

    // Update is called once per frame
    //void Update () {
    //	
    //}

    void UpdateUI()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        weaponText.text = target.Weapons[target.currentWeapon].name + ": " + target.Weapons[target.currentWeapon].currentAmmo + " / " + target.Weapons[target.currentWeapon].maxAmmo;
    }
}
