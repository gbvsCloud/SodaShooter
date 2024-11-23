using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soda : Shoot
{
    protected override void Awake()
    {
        base.Awake();
        shootVelocity = 14;
        shootDamage = 1.5f;
        penetration = 2;
    }
}




