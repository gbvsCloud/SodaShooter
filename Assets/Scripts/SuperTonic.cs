using UnityEngine;

public class SuperTonic : Shoot
{
    protected override void Awake()
    {
        base.Awake();
        shootVelocity = 14;
        shootDamage = 1.5f;
        penetration = 2;
    }
}




