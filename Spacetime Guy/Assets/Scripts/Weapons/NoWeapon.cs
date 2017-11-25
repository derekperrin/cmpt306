using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoWeapon : Weapon {

    public NoWeapon() : 
        base(
            null,                                        // character that is holding the Pistol
            null,                                        // Bullet prefab
            0f,                                          // Shoot rate
            0f,                                          // Bullet speed
            0f,                                          // Bullet damage
            0,                                           // Max ammo
            0,                                           // Current ammo
            0f,                                          // bulletXOffset
            0f                                           // bulletYOffset
        )
    {}

    public override void Fire(Vector2 direction)
    {
        // Do nothing
    }
}
