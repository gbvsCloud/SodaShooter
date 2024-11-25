using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Upgrade
{
    public int upgradeCost;
    public int upgradeLevel = 0;
    public int upgradeMaxLevel;

    public bool CanAffordUpgrade(Player player) => upgradeLevel < upgradeMaxLevel && player.stats.gold >= upgradeCost;
    public abstract void ApplyUpgrade(Player player);

    public bool TryAffordUpgrade(Player player)
    {
        if(CanAffordUpgrade(player))
        {
            player.stats.gold -= upgradeCost;
            ApplyUpgrade(player);
            return true;
        }
        else
        {
            return false;
        }
        
    }
}
