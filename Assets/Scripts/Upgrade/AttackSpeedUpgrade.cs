using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpeedUpgrade : Upgrade
{
    public AttackSpeedUpgrade()
    {
        upgradeCost = 100;
        upgradeMaxLevel = 10;
    }

    public override void ApplyUpgrade(Player player)
    {
        player.stats.shootReductionStack++;
        upgradeLevel++;
        upgradeCost += upgradeLevel * 50;
    }


}
