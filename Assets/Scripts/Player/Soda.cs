using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soda : Shoot
{
    protected override void Awake()
    {
        base.Awake();
        shootVelocity = 20;
        shootDamage = 3f;
        penetration = 2;
    }

    
}




