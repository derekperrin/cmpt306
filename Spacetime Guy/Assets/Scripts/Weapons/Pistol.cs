using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon {

    public override void Initialize(GameObject player)
    {
        Initialize(
           "Pistol",
            player,                                      // character that is holding the Pistol
            (GameObject)Resources.Load("Prefab/Bullet"), // Bullet prefab
            1f,                                          // Shoot rate
            100,                                         // Bullet speed
            10f,                                         // Bullet damage
            100,                                         // Max ammo
            100,                                         // Current ammo
            0f,                                          // bulletXOffset
            0f                                           // bulletYOffset
        );
    }
}
