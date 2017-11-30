using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : Weapon {
   

    public override void Initialize(GameObject player)
    {
        Initialize(
           "Machine Gun",
            player,                                      // character that is holding the Machine Gun
            (GameObject)Resources.Load("Prefab/Bullet"), // Bullet prefab
            0.01f,                                       // Shoot rate
            100,                                         // Bullet speed
            10f,                                         // Bullet damage
            500,                                       // Max ammo
            500,                                       // Current ammo
            0f,                                          // bulletXOffset
            0f                                           // bulletYOffset
        );
    }
}
