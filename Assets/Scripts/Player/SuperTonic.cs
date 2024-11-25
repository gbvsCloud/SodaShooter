using UnityEngine;

public class SuperTonic : Shoot
{
    protected override void Awake()
    {
        base.Awake();
        shootVelocity = 8;
        shootDamage = 1.5f;
        penetration = 6;
    }
}




