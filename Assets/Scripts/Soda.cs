using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soda : Shoot
{
    protected override void Start()
    {
        base.Start();
        shootVelocity = 8;
        shootDamage = 1.5f;
        rigidBody.velocity = new Vector2(0, shootVelocity);
    }
}
