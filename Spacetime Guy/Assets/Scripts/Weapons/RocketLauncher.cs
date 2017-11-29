using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : Weapon
{
    public override void Initialize(GameObject player)
    {
        Initialize(
            player,                                      // character that is holding the Machine Gun
            (GameObject)Resources.Load("Prefab/Rocket"), // Rocket prefab
            1.5f,                                        // Shoot rate
            100,                                         // Bullet speed
            50f,                                         // Bullet damage
            6,                                           // Max ammo
            6,                                           // Current ammo
            0f,                                          // bulletXOffset
            0f                                           // bulletYOffset
        );
    }
}
